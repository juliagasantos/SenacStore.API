using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SenacStore.API.DTOs;
using SenacStore.API.Interfaces;
using SenacStore.API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SenacStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CadastroController : ControllerBase
    {
        private readonly ICadastroRepository _cadastroRepository;

        public CadastroController(ICadastroRepository cadastroRepository)
        {
            _cadastroRepository = cadastroRepository;
        }

        // GET: api/<ProdutoController>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var cadastros = await _cadastroRepository.GetAllAsync();
            var cadastrosDTO = cadastros.Select(cadastro => new CadastroOutputDTO
            {
                Id = cadastro.Id,
                Nome = cadastro.Nome,
                Cpf = cadastro.Cpf,
                Email = cadastro.Email,
                Telefone = cadastro.Telefone,
                Endereco = cadastro.Endereco,
                Nro = cadastro.Nro,
                Bairro = cadastro.Bairro,
                Cidade = cadastro.Cidade,
                Estado = cadastro.Estado,
                DataCadastro = cadastro.DataCadastro

            }).ToList();

            return Ok(cadastrosDTO);
        }

        // GET api/<ProdutoController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var cadastro = await _cadastroRepository.GetByIdAsync(id);

            if (cadastro == null)
            {
                return NotFound($"Cadastro com ID {id} não encontrado.");
            }
            else
            {
                var cadastroDTO = new CadastroOutputDTO
                {
                    Id = cadastro.Id,
                    Nome = cadastro.Nome,
                    Cpf = cadastro.Cpf,
                    Email = cadastro.Email,
                    Telefone = cadastro.Telefone,
                    Endereco = cadastro.Endereco,
                    Nro = cadastro.Nro,
                    Bairro = cadastro.Bairro,
                    Cidade = cadastro.Cidade,
                    Estado = cadastro.Estado,
                    DataCadastro = cadastro.DataCadastro

                };
                return Ok(cadastroDTO);
            }
        }

        //create
        [HttpPost]
        public async Task<IActionResult> Create(CadastroInputDTO cadastroDTO)
        {
            var cadastro = new Cadastro
            {
                Nome = cadastroDTO.Nome,
                Cpf = cadastroDTO.Cpf,
                Email = cadastroDTO.Email,
                Telefone = cadastroDTO.Telefone,
                Endereco = cadastroDTO.Endereco,
                Nro = cadastroDTO.Nro,
                Bairro = cadastroDTO.Bairro,
                Cidade = cadastroDTO.Cidade,
                Estado = cadastroDTO.Estado,
                DataCadastro = DateTime.Now

            };
            await _cadastroRepository.CreateCadastroAsync(cadastro);
            //return CreatedAtAction(nameof(GetByIdAsync), new { nome = produtoDTO.Nome }, produtoDTO);
            return Ok("Cadastro criado com sucesso!");
        }

        //Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _cadastroRepository.DeleteCadastroAsync(id);
            return Ok();

        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] CadastroOutputDTO cadastroDTO)
        {
            var cadastro = new Cadastro
            {
                Id = cadastroDTO.Id,
                Nome = cadastroDTO.Nome,
                Cpf = cadastroDTO.Cpf,
                Email = cadastroDTO.Email,
                Telefone = cadastroDTO.Telefone,
                Endereco = cadastroDTO.Endereco,
                Nro = cadastroDTO.Nro,
                Bairro = cadastroDTO.Bairro,
                Cidade = cadastroDTO.Cidade,
                Estado = cadastroDTO.Estado,
                DataCadastro = DateTime.Now
            };
            await _cadastroRepository.UpdateCadastroAsync(cadastro);
            return Ok();
        }
    }
}
