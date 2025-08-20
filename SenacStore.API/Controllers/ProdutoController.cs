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
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        // GET: api/<ProdutoController>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var produtos = await _produtoRepository.GetAllAsync();
            var produtosDTO = produtos.Select(produto => new ProdutoDTO
            {
                Id = produto.Id,
                Nome = produto.Nome,
                Descricao = produto.Descricao,
                Preco = produto.Preco,
                Categoria = produto.Categoria,
                Imagem = produto.Imagem,
                Nota = produto.Nota,
                EhLancamento = produto.EhLancamento
            }).ToList();

            return Ok(produtosDTO);
        }

        // GET api/<ProdutoController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var produto = await _produtoRepository.GetByIdAsync(id);

            var produtoDTO = new ProdutoDTO
            {
                Id = produto.Id,
                Nome = produto.Nome,
                Descricao = produto.Descricao,
                Preco = produto.Preco,
                Categoria = produto.Categoria,
                Imagem = produto.Imagem,
                Nota = produto.Nota,
                EhLancamento = produto.EhLancamento
            };
            return Ok(produtoDTO);
        }

        // PUT api/<ProdutoController>/5
        [HttpPost]
        public async Task<IActionResult> Create(ProdutoDTO produtoDTO)
        {
            var produto = new Produto
            {
                Id = produtoDTO.Id,
                Nome = produtoDTO.Nome,
                Descricao = produtoDTO.Descricao,
                Preco = produtoDTO.Preco,
                Categoria = produtoDTO.Categoria,
                Imagem = produtoDTO.Imagem,
                Nota = produtoDTO.Nota,
                EhLancamento = produtoDTO.EhLancamento

            };
            await _produtoRepository.CreateProdutoAsync(produto);
            //return CreatedAtAction(nameof(GetByIdAsync), new { id = produto.Id }, produto);
            return Ok();
        }

        // DELETE api/<ProdutoController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _produtoRepository.DeleteProdutoAsync(id);
            return Ok();

        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] ProdutoDTO produtoDTO)
        {
            var produto = new Produto
            {
                Id = produtoDTO.Id,
                Nome = produtoDTO.Nome,
                Descricao = produtoDTO.Descricao,
                Preco = produtoDTO.Preco,
                Categoria = produtoDTO.Categoria,
                Imagem = produtoDTO.Imagem,
                Nota = produtoDTO.Nota,
                EhLancamento = produtoDTO.EhLancamento

            };
            await _produtoRepository.UpdateProdutoAsync(produto);
            return Ok();
        }
    }
}
