using System;
using Microsoft.AspNetCore.Mvc;
using Nyous_API_MongoDB.Domains;
using Nyous_API_MongoDB.Interfaces.Repositories;

namespace Nyous_API_MongoDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaController(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        // GET: api/<CategoriaController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_categoriaRepository.Listar());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<CategoriaController>/buscar/id/5
        [HttpGet("buscar/id/{id}")]
        public IActionResult Get(string id)
        {
            try
            {
                return Ok(_categoriaRepository.BuscarPorId(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<CategoriaController>
        [HttpPost]
        public IActionResult Post([FromBody] Categoria categoria)
        {
            try
            {
                return Ok(_categoriaRepository.Adicionar(categoria));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<CategoriaController>/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] Categoria categoria)
        {
            try
            {
                return Ok(_categoriaRepository.Atualizar(id, categoria));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<CategoriaController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                _categoriaRepository.Deletar(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}