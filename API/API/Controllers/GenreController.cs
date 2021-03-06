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
    public class GenreController : ControllerBase
    {
        private readonly IGenreService _genreService;
        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GenreDTO>>> Get()
        {
            try
            {
                IEnumerable<GenreDTO> genre = await _genreService.GetAllGenre();
                if (genre == null)
                    return NotFound();
                return new ObjectResult(genre);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GenreDTO>> Get([FromRoute]string id)
        {
            try
            {
                GenreDTO genre = await _genreService.GetGenre(id);
                if (genre == null)
                    return NotFound();
                return new ObjectResult(genre);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public ActionResult Post(IFormCollection data)
        {
            try 
            {
                var name = data["name"].FirstOrDefault();
                var description = data["description"].FirstOrDefault();
                var imageFile = data.Files.FirstOrDefault();
                GenreDTO genreDTO = new GenreDTO();
                genreDTO.Name = name;
                genreDTO.Description = description;
                genreDTO.File = imageFile;
                _genreService.Create(genreDTO);
                return Ok();
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
                var id= data["id"].FirstOrDefault();
                var name = data["name"].FirstOrDefault();
                var description = data["description"].FirstOrDefault();
                var imageFile = data.Files.FirstOrDefault();
                GenreDTO genreDTO = new GenreDTO();
                genreDTO.Id = id;
                genreDTO.Name = name;
                genreDTO.Description = description;
                genreDTO.File = imageFile;
                _genreService.Update(genreDTO);
                return Ok(genreDTO);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<GenreDTO>> Delete(string id)
        {
            try
            {
                GenreDTO genre = await _genreService.GetGenre(id);
                if (genre == null)
                    return NotFound();
                await _genreService.Delete(genre);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}