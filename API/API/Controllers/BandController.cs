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
        public ActionResult PostBand(IFormCollection data)
        {
            try
            {
                var name = data["name"].FirstOrDefault();
                var description = data["description"].FirstOrDefault();
                var imageFile = data.Files.FirstOrDefault();
                var foundationDate = data["foundationDate"].FirstOrDefault();
                var countryCode= data["countryCode"].FirstOrDefault();
                var genreId= data["genreId"].FirstOrDefault();
                BandDto bandDto = new BandDto();
                bandDto.Name = name;
                bandDto.Description = description;
                bandDto.File = imageFile;
                bandDto.CountryCode = countryCode;
                bandDto.FoundationDate = Convert.ToDateTime(foundationDate);
                bandDto.GenreId = genreId;
                _bandService.Create(bandDto);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BandDto>>> Get(string genreId)
        {
            try
            {
                IEnumerable<BandDto> band = await _bandService.GetBand(genreId);
                if (band == null)
                    return NotFound();
                return new ObjectResult(band);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BandDto>> GetId([FromRoute] string id)
        {
            try
            {
                BandDto band = await _bandService.GetBandId(id);
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
        public ActionResult Put(IFormCollection data)
        {
            if (data == null)
                return NotFound();
            try
            {
                var id = data["id"].FirstOrDefault();
                var name = data["name"].FirstOrDefault();
                var description = data["description"].FirstOrDefault();
                var imageFile = data.Files.FirstOrDefault();
                var foundationDate = data["foundationDate"].FirstOrDefault();
                var countryCode = data["countryCode"].FirstOrDefault();
                var genreId = data["genreId"].FirstOrDefault();
                BandDto bandDto = new BandDto();
                bandDto.Id = id;
                bandDto.Name = name;
                bandDto.Description = description;
                bandDto.File = imageFile;
                bandDto.CountryCode = countryCode;
                bandDto.FoundationDate = Convert.ToDateTime(foundationDate);
                bandDto.GenreId = genreId;
                _bandService.Update(bandDto);
                return Ok(bandDto);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
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
