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
    public class AlbumService : IAlbumService
    {
        private readonly IMapper _mapper;
        readonly UnitOfWork unitOfWork;
        public IConfiguration Configuration { get; }
        readonly string _contentFolder;

        public AlbumService(dp_musicContext context, IMapper mapper)
        {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            unitOfWork = new UnitOfWork(context);
            _mapper = mapper;
            _contentFolder = config["Images"];
        }

        public Task<IEnumerable<AlbumDto>> GetAlbum(string id)
        {
            throw new NotImplementedException();
        }

        public async Task Create(AlbumDto albumDto)
        {
            var album = _mapper.Map<AlbumDto, Album>(albumDto);
            album.Id = Guid.NewGuid().ToString();
            if(!unitOfWork.Band.Find(u => u.Id == album.BandId).Any())
                throw new Exception("Band not found!");


            //Images
            if (albumDto.File != null)
            {
                album.Image = album.Id + ".png";
                using (FileStream fileStream = File.Create(_contentFolder + album.Id + ".png"))
                {
                    albumDto.File.CopyTo(fileStream);
                    fileStream.Flush();
                }

            }


            unitOfWork.Album.Create(album);
            await unitOfWork.SaveAsync();
        }
    }
}
