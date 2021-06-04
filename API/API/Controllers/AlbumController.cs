using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
        public async Task<ActionResult> Put([FromForm] AlbumDto albumDto)
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
