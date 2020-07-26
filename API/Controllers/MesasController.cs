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
    public class MesasController : ControllerBase
    {
        private readonly MesasRepository _repository;
        

        public MesasController(MesasRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<List<MesasDTO>>> Get()
        {
            var list = await _repository.GetAllDto();
            if (list.Count == 0)
            {
                return NotFound();
            }
            return list;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Mesas>> GetById(int id)
        {
            var list = await _repository.getById(id);
            if (list == null)
            {
                return NotFound();
            }
            return list;
        }

        [HttpGet("orders/{id}")]
        public async Task<ActionResult<List<OrdenesDTO>>> GetTableOrder(int id)
        {
            var list = await _repository.GetOrders(id);
            if (list == null)
            {
                return NotFound();
            }
            return list;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Mesas>> Delete(int id)
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
        public async Task<ActionResult> Post(Mesas mesa)
        {
            if (ModelState.IsValid)
            {
                await _repository.Add(mesa);
                return NoContent();
            }
            return BadRequest();
        }

        [HttpPost("{id}")]
        public async Task<ActionResult> Complete(int id)
        {
           
            var result = await _repository.Complete(id);
            if (result)
            {
                return NoContent();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Post(int id, Mesas mesa)
        {
            if (ModelState.IsValid)
            {
                var response = await _repository.UpdateOrd(id, mesa);
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

        [HttpPatch("{id}")]
        public async Task<ActionResult> ChangeStatus(int id, Mesas mesa)
        {
            if (ModelState.IsValid)
            {
                var cambio = await _repository.Status(id,mesa);
                if (cambio)
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