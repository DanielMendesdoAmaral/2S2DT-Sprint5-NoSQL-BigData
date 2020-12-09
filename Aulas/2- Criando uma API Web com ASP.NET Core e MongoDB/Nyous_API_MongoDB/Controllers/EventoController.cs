using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Nyous_API_MongoDB.Domains;
using Nyous_API_MongoDB.Interfaces.Repositories;

namespace Nyous_API_MongoDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventoController : ControllerBase
    {
        private readonly IEventoRepository _eventoRepository;

        public EventoController(IEventoRepository eventoRepository)
        {
            _eventoRepository = eventoRepository;
        }

        // GET: api/<EventoController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_eventoRepository.Listar());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<EventoController>/buscar/id/5
        [HttpGet("buscar/id/{id}")]
        public IActionResult Get(string id)
        {
            try
            {
                return Ok(_eventoRepository.BuscarPorId(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<EventoController>
        [HttpPost]
        public IActionResult Post([FromBody] Evento evento)
        {
            try
            {
                return Ok(_eventoRepository.Adicionar(evento));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<EventoController>/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] Evento evento)
        {
            try
            {
                return Ok(_eventoRepository.Atualizar(id, evento));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<EventoController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                _eventoRepository.Deletar(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}