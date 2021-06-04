using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        private readonly IAlbumService _albumService;

        public AlbumController(IAlbumService albumService)
        {
            _albumService = albumService;
        }


        [HttpPost]
        public async Task<ActionResult<AlbumDto>> Post(IFormCollection data)
        {
            try
            {
                var name = data["name"].FirstOrDefault();
                var description = data["description"].FirstOrDefault();
                var year = data["year"].FirstOrDefault();
                var imageFile = data.Files.FirstOrDefault();
                var bandId = data["bandId"].FirstOrDefault();

                AlbumDto albumDto = new AlbumDto();
                albumDto.Name = name;
                albumDto.Description = description;
                albumDto.File = imageFile;
                albumDto.Year = int.Parse(year);
                albumDto.BandId = bandId;

                if (albumDto.Year == null)
                    return BadRequest("Year null");
                await _albumService.Create(albumDto);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        //для показу на дипломі
        [HttpPost]
        [Route("TestApi")]
        public async Task<ActionResult<AlbumDto>> PostTest([FromForm] AlbumDto albumDto)
        {
            try
            {
                if (albumDto.Year == null)
                    return BadRequest("Year null");
                await _albumService.Create(albumDto);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AlbumDto>>> Get(string bandId)
        {
            try
            {
                IEnumerable<AlbumDto> albums = await _albumService.GetAlbum(bandId);
                if (albums == null)
                    return NotFound();
                return new ObjectResult(albums);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<ActionResult> Put(IFormCollection data)
        {
            if (data == null)
                return NotFound();
            try
            {
                var id = data["id"].FirstOrDefault();
                var name = data["name"].FirstOrDefault();
                var description = data["description"].FirstOrDefault();
                var year = data["year"].FirstOrDefault();
                var imageFile = data.Files.FirstOrDefault();
                var bandId = data["bandId"].FirstOrDefault();

                AlbumDto albumDto = new AlbumDto();
                albumDto.Id = id;
                albumDto.Name = name;
                albumDto.Description = description;
                albumDto.File = imageFile;
                albumDto.Year = int.Parse(year);
                albumDto.BandId = bandId;

                await _albumService.Update(albumDto);
                return Ok(albumDto);
            }
            catch
            {
                return BadRequest();
            }
        }

        //для показу на дипломі
        [HttpPut] 
        [Route("TestApi")]
        public async Task<ActionResult> PutTest([FromForm] AlbumDto albumDto)
        {
            if (albumDto == null)
                return NotFound();
            try
            {
                await _albumService.Update(albumDto);
                return Ok(albumDto);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<AlbumDto>> Delete(string id)
        {
            try
            {
                AlbumDto album = await _albumService.GetAlbumId(id);
                if (album == null)
                    return NotFound();
                await _albumService.Delete(album);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
