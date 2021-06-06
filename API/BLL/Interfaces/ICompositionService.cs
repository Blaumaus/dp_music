using BLL.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ICompositionService
    {
        Task<IEnumerable<CompositionDto>> GetComposition(string albumId, string bandId);
        Task<IEnumerable<CompositionDto>> GetAllComposition(string genreId);
        Task Create(CompositionDto compositionDto);
        Task<CompositionDto> GetCompositionId(string id);
        Task Update(CompositionDto compositionDto);
        Task Delete(CompositionDto compositionDto);
    }
}
