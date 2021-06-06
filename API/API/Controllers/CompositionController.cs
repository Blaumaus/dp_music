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
    public class CompositionController : ControllerBase
    {
        private readonly ICompositionService _compositionService;

        public CompositionController(ICompositionService compositionService)
        {
            _compositionService = compositionService;
        }

        [HttpPost]
        public async Task<ActionResult<CompositionDto>> Post(IFormCollection data)
        {
            try
            {
                var name = data["name"].FirstOrDefault();
                var description = data["description"].FirstOrDefault();
                var year = data["year"].FirstOrDefault();
                var imageFile = data.Files.FirstOrDefault();
                var bandId = data["bandId"].FirstOrDefault();
                var albumId = data["albumId"].FirstOrDefault();
                var genreId = data["ganreId"].FirstOrDefault();
                var lyrics = data["lyrics"].FirstOrDefault();

                CompositionDto composition = new CompositionDto();
                composition.Name = name;
                composition.Description = description;
                composition.File = imageFile;
                composition.Year = int.Parse(year);
                composition.BandId = bandId;
                composition.AlbumId = albumId;
                composition.GenreId = genreId;
                composition.Lyrics = lyrics;

                if (composition.Year == null)
                    return BadRequest("Year null");
                await _compositionService.Create(composition);
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

        [HttpGet]
        [Route("All")]
        public async Task<ActionResult<IEnumerable<CompositionDto>>> GetAll(string genreId)
        {
            try
            {
                IEnumerable<CompositionDto> compositions = await _compositionService.GetAllComposition(genreId);
                if (compositions == null)
                    return NotFound();
                return new ObjectResult(compositions);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("TestApi")]
        public async Task<ActionResult> PutTest(IFormCollection data)
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
                var albumId = data["albumId"].FirstOrDefault();
                var genreId = data["ganreId"].FirstOrDefault();
                var lyrics = data["lyrics"].FirstOrDefault();

                CompositionDto composition = new CompositionDto();
                composition.Id = id;
                composition.Name = name;
                composition.Description = description;
                composition.File = imageFile;
                composition.Year = int.Parse(year);
                composition.BandId = bandId;
                composition.AlbumId = albumId;
                composition.GenreId = genreId;
                composition.Lyrics = lyrics;

                await _compositionService.Update(composition);
                return Ok(composition);
            }
            catch
            {
                return BadRequest();
            }
        }

        //для показу на дипломі
        [HttpPut]
        [Route("TestApi")]
        public async Task<ActionResult> PutTest([FromForm] CompositionDto compositionDto)
        {
            if (compositionDto == null)
                return NotFound();
            try
            {
                await _compositionService.Update(compositionDto);
                return Ok(compositionDto);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CompositionDto>> Delete(string id)
        {
            try
            {
                CompositionDto composition = await _compositionService.GetCompositionId(id);
                if (composition == null)
                    return NotFound();
                await _compositionService.Delete(composition);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
