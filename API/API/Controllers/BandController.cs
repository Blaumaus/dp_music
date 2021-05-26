using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<ActionResult<BandDto>> PostBand(string id, [FromForm] BandDto bandDto)
        {
            try
            {
                await _bandService.Create(id, bandDto);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet]
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
    }
}
