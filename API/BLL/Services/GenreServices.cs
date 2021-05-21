
using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL;
using DAL.Repositories;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;


namespace BLL.Services
{
    public class GenreServices : IGenreService
    {
        private readonly IMapper _mapper;
        readonly UnitOfWork unitOfWork;
        public IConfiguration Configuration { get; }
        readonly string _contentFolder;
        public GenreServices(dp_musicContext context, IMapper mapper)
        {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            unitOfWork = new UnitOfWork(context);
            _mapper = mapper;
            _contentFolder = config["Images"];
        }

        public async Task Delete(GenreDTO genreDTO)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), genreDTO.Image.Replace("//", "\\"));
            unitOfWork.Genre.Delete(genreDTO.Id);

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            await unitOfWork.SaveAsync();
        }

        public async Task<GenreDTO> GetGenre(string id)
        {
            var genre = await Task.Run(() => _mapper.Map<Genre, GenreDTO>(unitOfWork.Genre.Get(id)));
            genre.Image = _contentFolder + genre.Image;
            return genre;
        }

        public async Task Update(GenreDTO genreDTO)
        {
            var genre = unitOfWork.Genre.Get(genreDTO.Id);
            if(genreDTO.Name != null)
                genre.Name = genreDTO.Name;
            if (genreDTO.Description != null)
                genre.Description = genreDTO.Description;

            
            if (genreDTO.File != null)
            {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), _contentFolder.Replace("//", "\\"), genre.Image);
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);

                    using (FileStream fileStream = File.Create(_contentFolder + genre.Id + ".png"))
                    {
                        genreDTO.File.CopyTo(fileStream);
                        fileStream.Flush();
                    }
                }
            }

            unitOfWork.Genre.Update(genre);
            await unitOfWork.SaveAsync();
        }

        public async Task Create(GenreDTO genreDTO)
        {

            var genre = _mapper.Map<GenreDTO, Genre>(genreDTO);
            genre.Id = Guid.NewGuid().ToString();
            genre.Image = genre.Id + ".png";
            unitOfWork.Genre.Create(genre);
            if (genreDTO.File != null)
            {
                using (FileStream fileStream = File.Create(_contentFolder + genre.Id + ".png"))
                {
                    genreDTO.File.CopyTo(fileStream);
                    fileStream.Flush();
                }
            }
            await unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<GenreDTO>> GetAllGenre()
        {
            var genres = await Task.Run(() => _mapper.Map<IEnumerable<Genre>, IEnumerable<GenreDTO>>(unitOfWork.Genre.GetAll()));
            foreach( var genre in genres)
            {
                genre.Image = _contentFolder + genre.Image;
            }
            return genres;
        }
    }
}