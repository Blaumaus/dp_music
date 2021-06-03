using BLL.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IAlbumService
    {
        Task<IEnumerable<AlbumDto>> GetAlbum(string id);
        Task Create(AlbumDto albumDto);
    }
}
