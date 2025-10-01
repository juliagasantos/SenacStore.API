using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SenacStore.API.DTOs;
using SenacStore.API.Interfaces;
using SenacStore.API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SenacStore.API.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("MyPolicy")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaController(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        // GET: api/<ProdutoController>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var categorias = await _categoriaRepository.GetAllAsync();
            var categoriasDTO = categorias.Select(categoria => new CategoriaOutputDTO
            {
                Id = categoria.Id,
                Nome = categoria.Nome
            }).ToList();

            return Ok(categoriasDTO);
        }

        // GET api/<ProdutoController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var categoria = await _categoriaRepository.GetByIdAsync(id);

            if (categoria == null)
            {
                return NotFound($"Categoria com ID {id} não encontrada.");
            }
            else
            {
                var categoriaDTO = new CategoriaOutputDTO
                {
                    Id = categoria.Id,
                    Nome = categoria.Nome
                };
                return Ok(categoriaDTO);
            }
        }

        //create
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CategoriaInputDTO categoriaDTO)
        {
            var categoria = new Categoria
            {
                Nome = categoriaDTO.Nome

            };
            await _categoriaRepository.CreateCategoriaAsync(categoria);
            //return CreatedAtAction(nameof(GetByIdAsync), new { nome = produtoDTO.Nome }, produtoDTO);
            return Ok("Categoria criada com sucesso!");
        }

        //Delete
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            await _categoriaRepository.DeleteCategoriaAsync(id);
            return Ok();

        }


        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Put([FromBody] CategoriaOutputDTO categoriaDTO)
        {
            var categoria = new Categoria
            {
                Id = categoriaDTO.Id,
                Nome = categoriaDTO.Nome

            };
            await _categoriaRepository.UpdateCategoriaAsync(categoria);
            return Ok();
        }
    }
}
