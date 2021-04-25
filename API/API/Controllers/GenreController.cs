﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IGenreService _genreService;
        private readonly IMapper _mapper;

        public GenreController(IGenreService genreService, IMapper mapper)
        {
            _genreService = genreService;
            _mapper = mapper;
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
        public async Task<ActionResult<GenreDTO>> Get(string id)
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
        public async Task<ActionResult<GenreDTO>> Post(GenreDTO genreDTO)
        {
            try 
            { 
                await _genreService.Create(genreDTO);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(GenreDTO genreDTO)
        {
            if (genreDTO == null)
                return NotFound();
            try
            {
                await _genreService.Update(genreDTO);
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