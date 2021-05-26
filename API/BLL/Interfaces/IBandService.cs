﻿using BLL.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IBandService
    {
        Task<IEnumerable<BandDto>> GetBand(string id);
        Task Create(string genreId, BandDto bandDto);
    }
}
