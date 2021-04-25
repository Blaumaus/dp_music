using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class GenreServices : IGenreService
    {
        private readonly IMapper _mapper;
        readonly UnitOfWork unitOfWork;

        public GenreServices(dp_musicContext context, IMapper mapper)
        {
            unitOfWork = new UnitOfWork(context);
            _mapper = mapper;
        }

        public async Task Delete(GenreDTO genreDTO)
        {
            unitOfWork.Genre.Delete(genreDTO.Id);
            await unitOfWork.SaveAsync();
        }

        public async Task<GenreDTO> GetGenre(string id)
        {
            var genre = await Task.Run(() => _mapper.Map<Genre, GenreDTO>(unitOfWork.Genre.Get(id)));
            return genre;
        }

        public async Task Update(GenreDTO genreDTO)
        {
            var genre = unitOfWork.Genre.Get(genreDTO.Id);
            genre.Name = genreDTO.Name;
            genre.Image = genreDTO.Image;
            genre.Description = genreDTO.Description;

            unitOfWork.Genre.Update(genre);
            await unitOfWork.SaveAsync();
        }

        public async Task Create(GenreDTO genreDTO)
        {
            if (unitOfWork.Genre.Find(u => u.Name == genreDTO.Name).Any())
                throw new Exception("the genre has already been created");

            var genre = _mapper.Map<Genre>(genreDTO);
            unitOfWork.Genre.Create(genre);
            await unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<GenreDTO>> GetAllGenre()
        {
            var genre = await Task.Run(() => _mapper.Map<IEnumerable<Genre>, IEnumerable<GenreDTO>>(unitOfWork.Genre.GetAll()));
            return genre;
        }
    }
}
