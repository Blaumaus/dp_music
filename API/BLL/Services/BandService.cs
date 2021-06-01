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
            _contentFolder = config["Images"];
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
                    band.GenreId = id;

                    //Image
                    if (band.Image != null)
                        band.Image = _contentFolder + band.Image;
                    else
                        band.Image = _contentFolder + "default.png";

                    bands = bands.Append(band);
                }

                return bands;
            }

            return null;
        }

        public async Task Create(BandDto bandDto)
        {
            var band = _mapper.Map<BandDto, Band>(bandDto);
            band.Id = Guid.NewGuid().ToString();

            //Images
            if (bandDto.File != null)
            {
                band.Image = band.Id + ".png";
                using (FileStream fileStream = File.Create(_contentFolder + band.Id + ".png"))
                {
                    bandDto.File.CopyTo(fileStream);
                    fileStream.Flush();
                }

            }

            BandgenreDto bandgenreDto = new BandgenreDto
            {
                BandId = band.Id,
                GenreId = bandDto.GenreId
            };
            var bandgenre = _mapper.Map<BandgenreDto, Bandgenre>(bandgenreDto);

            unitOfWork.Bandgenre.Create(bandgenre);
            unitOfWork.Band.Create(band);
            await unitOfWork.SaveAsync();
        }

        public async Task Delete(BandDto bandDto)
        {
            //Images
            if (bandDto.Image != _contentFolder + "default.png")
            {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), bandDto.Image.Replace("//", "\\"));
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
            }

            unitOfWork.Band.Delete(bandDto.Id);
            unitOfWork.Bandgenre.Delete(bandDto.Id);
            await unitOfWork.SaveAsync();
        }

        public async Task<BandDto> GetBandId(string id)
        {
            var band = await Task.Run(() => _mapper.Map<Band, BandDto>(unitOfWork.Band.Get(id)));
            band.GenreId = id;

            //Images
            if (band.Image != null)
            {
                band.Image = _contentFolder + band.Image;

            }
            else
            {
                band.Image = _contentFolder + "default.png";
            }

            return band;
        }

        public async Task Update(BandDto bandDto)
        {
            var band = unitOfWork.Band.Get(bandDto.Id);
            if (bandDto.Name != null)
                band.Name = bandDto.Name;
                band.Description = bandDto.Description;
            if (bandDto.FoundationDate != null)
                band.FoundationDate = (DateTime)bandDto.FoundationDate;
                band.CountryCode = bandDto.CountryCode;


            //Images
            if (bandDto.File != null)
            {
                if(band.Image != null)
                {
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), _contentFolder.Replace("//", "\\"), band.Image);
                    if (File.Exists(filePath))
                        File.Delete(filePath);
                }
                band.Image = band.Id + ".png";
                using (FileStream fileStream = File.Create(_contentFolder + band.Id + ".png"))
                {
                    bandDto.File.CopyTo(fileStream);
                    fileStream.Flush();
                    band.Image = band.Id + ".png";
                }
            }

            if(bandDto.GenreId != null)
            {
                unitOfWork.Bandgenre.Delete(bandDto.Id);
                BandgenreDto bandgenreDto = new BandgenreDto
                {
                    BandId = band.Id,
                    GenreId = bandDto.GenreId
                };
                var bandgenre = _mapper.Map<BandgenreDto, Bandgenre>(bandgenreDto);
                unitOfWork.Bandgenre.Create(bandgenre);
            }

            unitOfWork.Band.Update(band);
            await unitOfWork.SaveAsync();
        }
    }
}
