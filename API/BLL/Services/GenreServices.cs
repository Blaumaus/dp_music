
using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL;
using DAL.Repositories;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            unitOfWork.Genre.Delete(genreDTO.Id);
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
            genre.Name = genreDTO.Name;
            ///
            ////
            //genre.Image = genreDTO.Image;
            genre.Description = genreDTO.Description;

            unitOfWork.Genre.Update(genre);
            await unitOfWork.SaveAsync();
        }

        public async Task Create(GenreDTO genreDTO)
        {

            var genre = _mapper.Map<GenreDTO, Genre>(genreDTO);
            genre.Id = Guid.NewGuid().ToString();
            genre.Image = genre.Id + ".png";
            unitOfWork.Genre.Create(genre);
            if (genreDTO.File.Length > 0)
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
<<<<<<< HEAD
            var genres = await Task.Run(() => _mapper.Map<IEnumerable<Genre>, IEnumerable<GenreDTO>>(unitOfWork.Genre.GetAll()));
            foreach( var genre in genres)
            {
                genre.Image = _contentFolder + genre.Image;
            }
            return genres;
=======
            var genre = await Task.Run(() => _mapper.Map<IEnumerable<Genre>, IEnumerable<GenreDTO>>(unitOfWork.Genre.GetAll()));
            foreach(var g in genre)
            {
                g.Image = _contentFolder + g.Image;
            }
            
            return genre;
>>>>>>> windowsForms
        }
    }
}