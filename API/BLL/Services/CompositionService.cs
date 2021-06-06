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
    public class CompositionService : ICompositionService
    {
        private readonly IMapper _mapper;
        readonly UnitOfWork unitOfWork;
        public IConfiguration Configuration { get; }
        readonly string _contentFolder;

        public CompositionService(dp_musicContext context, IMapper mapper)
        {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            unitOfWork = new UnitOfWork(context);
            _mapper = mapper;
            _contentFolder = config["Music"];
        }

        public async Task<IEnumerable<CompositionDto>> GetComposition(string albumId, string bandId)
        {
            if(albumId != null)
            {
                var compositionAlbum = await Task.Run(() => _mapper.Map<IEnumerable<Composition>, IEnumerable<CompositionDto>>(unitOfWork.Composition.GetAll())
                .Where(x => x.AlbumId == albumId));
                foreach (var composition in compositionAlbum)
                {
                    if (composition.FilePath != null)
                        composition.FilePath = _contentFolder + composition.FilePath;
                    else
                        throw new Exception("Composition not found!");
                }
                return compositionAlbum;
            }

            var compositionBand = await Task.Run(() => _mapper.Map<IEnumerable<Composition>, IEnumerable<CompositionDto>>(unitOfWork.Composition.GetAll())
                .Where(x => x.BandId == bandId));
            foreach (var composition in compositionBand)
            {
                if (composition.FilePath != null)
                    composition.FilePath = _contentFolder + composition.FilePath;
                else
                    throw new Exception("Composition not found!");
            }
            return compositionBand;
        }

        public async Task Create(CompositionDto compositionDto)
        {
            var composition = _mapper.Map<CompositionDto, Composition>(compositionDto);
            composition.Id = Guid.NewGuid().ToString();
            if (!unitOfWork.Album.Find(u => u.Id == compositionDto.AlbumId).Any())
                throw new Exception("Album not found!");
            if(compositionDto.File==null)
                throw new Exception("not specified Composition!");

            //Music
            if (compositionDto.File != null)
            {
                composition.FilePath = composition.Id + ".mp3";
                using (FileStream fileStream = File.Create(_contentFolder + composition.Id + ".mp3"))
                {
                    compositionDto.File.CopyTo(fileStream);
                    fileStream.Flush();
                }

            }


            unitOfWork.Composition.Create(composition);
            await unitOfWork.SaveAsync();
        }

        public Task<CompositionDto> GetCompositionId(string id)
        {
            throw new NotImplementedException();
        }

        public Task Update(CompositionDto compositionDto)
        {
            throw new NotImplementedException();
        }

        public Task Delete(CompositionDto compositionDto)
        {
            throw new NotImplementedException();
        }
    }
}
