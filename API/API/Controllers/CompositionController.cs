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
    public class CompositionController : ControllerBase
    {
        private readonly ICompositionService _compositionService;

        public CompositionController(ICompositionService compositionService)
        {
            _compositionService = compositionService;
        }

        //для показу на дипломі
        [HttpPost]
        [Route("TestApi")]
        public async Task<ActionResult<CompositionDto>> PostTest([FromForm] CompositionDto compositionDto)
        {
            try
            {
                if (compositionDto.Year == null)
                    return BadRequest("Year null");
                await _compositionService.Create(compositionDto);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompositionDto>>> Get(string albumId, string bandId)
        {
            try
            {
                IEnumerable<CompositionDto> compositions = await _compositionService.GetComposition(albumId, bandId); 
                if (compositions == null)
                    return NotFound();
                return new ObjectResult(compositions);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
