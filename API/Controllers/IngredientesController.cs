using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Database;
using DTOS;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Repository.Repository;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientesController : ControllerBase
    {
        private readonly IngredientesRepository _repository;
        private readonly IMapper _mapper;
        public IngredientesController(IngredientesRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<IngredientesDTO>>> Get()
        {
            var list = await _repository.GetAllDto();
            if(list.Count == 0)
            {
                return NotFound();
            }
            return list;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Ingredientes>> GetById(int id)
        {
            var list = await _repository.getById(id);
            if (list == null)
            {
                return NotFound();
            }
            return list;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Ingredientes>> Delete(int id)
        {
            var list = await _repository.getById(id);
            if (list == null)
            {
                return NotFound();
            }
            await _repository.Delete(id);
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult> Post(Ingredientes ingrediente)
        {
            if (ModelState.IsValid)
            {
                await _repository.Add(ingrediente);
                return NoContent();
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Post(int id,Ingredientes ingrediente)
        {
            if (ModelState.IsValid)
            {
                var response = await _repository.UpdateIngr(id, ingrediente);
                if (response)
                {
                    return NoContent();
                } else
                {
                    return StatusCode(500);
                }
            }
            return BadRequest();
        }
    }
}