using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database.Models;
using DTOS;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Repository;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenesController : ControllerBase
    {
        private readonly OrdenesRepository _repository;
        public OrdenesController(OrdenesRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<List<OrdenesDTO>>> Get()
        {
            var list = await _repository.GetAllDto();
            if (list.Count == 0)
            {
                return NotFound();
            }
            return list;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Ordenes>> GetById(int id)
        {
            var list = await _repository.getById(id);
            if (list == null)
            {
                return NotFound();
            }
            return list;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Ordenes>> Delete(int id)
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
        public async Task<ActionResult> Post(Ordenes orden)
        {
            if (ModelState.IsValid)
            {
                await _repository.Add(orden);
                return NoContent();
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Post(int id, Ordenes orden)
        {
            if (ModelState.IsValid)
            {
                var response = await _repository.UpdateOrd(id, orden);
                if (response)
                {
                    return NoContent();
                }
                else
                {
                    return StatusCode(500);
                }
            }
            return BadRequest();
        }
    }
}