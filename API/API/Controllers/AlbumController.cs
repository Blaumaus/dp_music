using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
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
                await _albumService.Create(albumDto);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
