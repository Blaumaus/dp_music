
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
            if (genreDTO.Image != null)
            {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), genreDTO.Image.Replace("//", "\\"));
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
            }    
            unitOfWork.Genre.Delete(genreDTO.Id);
            await unitOfWork.SaveAsync();
        }

        public async Task<GenreDTO> GetGenre(string id)
        {
            var genre = await Task.Run(() => _mapper.Map<Genre, GenreDTO>(unitOfWork.Genre.Get(id)));
            if (genre.Image != null)
            {
                genre.Image = _contentFolder + genre.Image;

            }
            //else
            //{
            //    //Зроби тут тоді дефолтну картинку для жанра якусь, створи  в папці картинку з назовою defaultGenreImage.png 
            //    //genre.Image = _contentFolder + (і тут встав);
            //}

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
            if (genreDTO.File != null)
            {
                genre.Image = genre.Id + ".png";
                using (FileStream fileStream = File.Create(_contentFolder + genre.Id + ".png"))
                {
                    genreDTO.File.CopyTo(fileStream);
                    fileStream.Flush();
                }
               
            }
            unitOfWork.Genre.Create(genre);
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