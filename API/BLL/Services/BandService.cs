using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL;
using DAL.Repositories;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class BandService : IBandService
    {
        private readonly IMapper _mapper;
        readonly UnitOfWork unitOfWork;
        public IConfiguration Configuration { get; }
        readonly string _contentFolder;

        public BandService(dp_musicContext context, IMapper mapper)
        {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            unitOfWork = new UnitOfWork(context);
            _mapper = mapper;
            _contentFolder = config["Iamges"];
        }

        public async Task<IEnumerable<BandDto>> GetBand(string id)
        {
            var bandsgenre = await Task.Run(() => _mapper.Map<IEnumerable<Bandgenre>, IEnumerable<BandgenreDto>>(unitOfWork.Bandgenre.GetAll()).Where(x => x.GenreId == id)); 
            
            if(bandsgenre != null)
            {
                IEnumerable<BandDto> bands = new BandDto[] { };
                foreach (var bandgenre in bandsgenre)
                {
                    BandDto band = await Task.Run(() => _mapper.Map<Band, BandDto>(unitOfWork.Band.Get(bandgenre.BandId)));
                    bands = bands.Append(band);
                }

                return bands;
            }
            
            //Images

            return null;
        }

        public async Task Create(string genreId, BandDto bandDto)
        {
            var band = _mapper.Map<BandDto, Band>(bandDto);
            band.Id = Guid.NewGuid().ToString();

            //Images

            BandgenreDto bandgenreDto = new BandgenreDto
            {
                BandId = band.Id,
                GenreId = genreId
            };
            var bandgenre = _mapper.Map<BandgenreDto, Bandgenre>(bandgenreDto);

            unitOfWork.Bandgenre.Create(bandgenre);
            unitOfWork.Band.Create(band);
            await unitOfWork.SaveAsync();
        }
    }
}
