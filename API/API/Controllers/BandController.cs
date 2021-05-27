using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BandController : ControllerBase
    {
        private readonly IBandService _bandService;

        public BandController(IBandService bandService)
        {
            _bandService = bandService;
        }

        [HttpPost]
        public async Task<ActionResult<BandDto>> PostBand([FromForm] BandDto bandDto)
        {
            try
            {
                await _bandService.Create(bandDto);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("id")]
        public async Task<ActionResult<IEnumerable<BandDto>>> Get( string id)
        {
            try
            {
                IEnumerable<BandDto> band = await _bandService.GetBand(id);
                if (band == null)
                    return NotFound();
                return new ObjectResult(band);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromForm] BandDto bandDto)
        {
            if (bandDto == null)
                return NotFound();
            try
            {
                await _bandService.Update(bandDto);
                return Ok(bandDto);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("id")]
        public async Task<ActionResult<BandDto>> Delete(string id)
        {
            try
            {
                BandDto band = await _bandService.GetBandId(id);
                if (band == null)
                    return NotFound();
                await _bandService.Delete(band);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
