using Microsoft.AspNetCore.Authorization;
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
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        // GET: api/<UsuarioController>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var usuarios = await _usuarioRepository.GetAllAsync();
            var usuariosDTO = usuarios.Select(usuario => new UsuarioOutputDTO
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                Senha = usuario.Senha
            }).ToList();

            return Ok(usuariosDTO);
        }

        // GET api/<UsuarioController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(id);

            if (usuario == null)
            {
                return NotFound($"Usuario com ID {id} não encontrado.");
            }
            else
            {
                var usuarioDTO = new UsuarioOutputDTO
                {
                    Id = usuario.Id,
                    Nome = usuario.Nome,
                    Email = usuario.Email,
                    Senha = usuario.Senha,
                };
                return Ok(usuarioDTO);
            }
        }

        //create
        [HttpPost]
        public async Task<IActionResult> Create(UsuarioInputDTO usuarioDTO)
        {
            var usuario = new Usuario
            {
                Nome = usuarioDTO.Nome,
                Email = usuarioDTO.Email,
                Senha = usuarioDTO.Senha

            };
            await _usuarioRepository.CreateUsuarioAsync(usuario);
            //return CreatedAtAction(nameof(GetByIdAsync), new { nome = usuarioDTO.Nome }, usuarioDTO);
            return Ok("Usuario criado com sucesso!");
        }

        //Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _usuarioRepository.DeleteUsuarioAsync(id);
            return Ok();

        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] UsuarioOutputDTO usuarioDTO)
        {
            var usuario = new Usuario
            {
                Id = usuarioDTO.Id,
                Nome = usuarioDTO.Nome,
                Email = usuarioDTO.Email,
                Senha = usuarioDTO.Senha

            };
            await _usuarioRepository.UpdateUsuarioAsync(usuario);
            return Ok();
        }
    }
}
