using Microsoft.EntityFrameworkCore;
using SenacStore.API.Data;
using SenacStore.API.Interfaces;
using SenacStore.API.Models;

namespace SenacStore.API.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly SenacStoreDbContext _senacStoreDbContext;

        public ProdutoRepository(SenacStoreDbContext senacStoreDbContext)
        {
            _senacStoreDbContext = senacStoreDbContext;
        }

        public async Task CreateProdutoAsync(Produto produto)
        {
            await _senacStoreDbContext.Produtos.AddAsync(produto);
            await _senacStoreDbContext.SaveChangesAsync();
        }

        public async Task DeleteProdutoAsync(int id)
        {
           var produto = await _senacStoreDbContext.Produtos.FindAsync(id);
            if(produto != null)
            {
                _senacStoreDbContext.Produtos.Remove(produto);
                await _senacStoreDbContext.SaveChangesAsync();
            }
        }

        public async Task<List<Produto>> GetAllAsync()
        {
            return await _senacStoreDbContext.Produtos.ToListAsync();
        }

        public async Task<Produto> GetByIdAsync(int id)
        {
           return await _senacStoreDbContext.Produtos.FindAsync(id);
        }

        public async Task UpdateProdutoAsync(Produto produto)
        {
            _senacStoreDbContext.Produtos.Update(produto);
            await _senacStoreDbContext.SaveChangesAsync();
        }
    }
}
