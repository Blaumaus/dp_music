using BLL.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IAlbumService
    {
        Task<IEnumerable<AlbumDto>> GetAlbum(string id);
        Task Create(AlbumDto albumDto);
        Task<AlbumDto> GetAlbumId(string id);
        Task Update(AlbumDto albumDto);
        Task Delete(AlbumDto albumDto);
    }
}
