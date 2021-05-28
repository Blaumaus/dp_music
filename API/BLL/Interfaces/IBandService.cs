using BLL.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IBandService
    {
        Task<IEnumerable<BandDto>> GetBand(string id);
        Task<BandDto> GetBandId(string id);
        Task Create(BandDto bandDto);
        Task Delete(BandDto bandDto);
        Task Update(BandDto bandDto);
    }
}
