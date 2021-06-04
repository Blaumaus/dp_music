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

        public async Task<IEnumerable<AlbumDto>> GetAlbum(string id)
        {
            if(id == null)
            {
                var albumAll = await Task.Run(() => _mapper.Map<IEnumerable<Album>, IEnumerable<AlbumDto>>(unitOfWork.Album.GetAll()));
                foreach (var album in albumAll)
                {
                    if (album.Image != null)
                        album.Image = _contentFolder + album.Image;
                    else
                        album.Image = _contentFolder + "default.png";
                }
                return albumAll;
            }

            var albums = await Task.Run(() => _mapper.Map<IEnumerable<Album>, IEnumerable<AlbumDto>>(unitOfWork.Album.GetAll()).Where(e => e.BandId == id));
            foreach (var album in albums)
            {
                if (album.Image != null)
                    album.Image = _contentFolder + album.Image;
                else
                    album.Image = _contentFolder + "default.png";
            }
            return albums;
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

        public async Task<AlbumDto> GetAlbumId(string id)
        {
            var album = await Task.Run(() => _mapper.Map<Album, AlbumDto>(unitOfWork.Album.Get(id)));
            if (album.Image != null)
            {
                album.Image = _contentFolder + album.Image;

            }
            else
            {
                album.Image = _contentFolder + "default.png";
            }

            return album;
        }

        public async Task Update(AlbumDto albumDto)
        {
            var album = unitOfWork.Album.Get(albumDto.Id);
            if (albumDto.Name != null)
                album.Name = albumDto.Name;
            if (albumDto.BandId != null)
                album.BandId = albumDto.BandId;
            if (albumDto.Description != null)
                album.Description = albumDto.Description;
            if (albumDto.Year != null)
                album.Year = (int)albumDto.Year;


            if (albumDto.File != null)
            {
                if (album.Image != null)
                {
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), _contentFolder.Replace("//", "\\"), album.Image);
                    if (File.Exists(filePath))
                        File.Delete(filePath);
                }
                album.Image = album.Id + ".png";
                using (FileStream fileStream = File.Create(_contentFolder + album.Id + ".png"))
                {
                    albumDto.File.CopyTo(fileStream);
                    fileStream.Flush();
                }
            }

            unitOfWork.Album.Update(album);
            await unitOfWork.SaveAsync();
        }

        public async Task Delete(AlbumDto albumDto)
        {
            //Images
            if (albumDto.Image != _contentFolder + "default.png")
            {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), albumDto.Image.Replace("//", "\\"));
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
            }

            unitOfWork.Album.Delete(albumDto.Id);
            await unitOfWork.SaveAsync();
        }
    }
}
