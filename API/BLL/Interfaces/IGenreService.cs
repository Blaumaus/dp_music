using BLL.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IGenreService
    {
        Task<IEnumerable<GenreDTO>> GetAllGenre();
        Task<GenreDTO> GetGenre(string id);
        Task Update(GenreDTO genreDTO);
        Task Delete(GenreDTO genreDTO);
        Task Create(GenreDTO genreDTO);
    }
}
