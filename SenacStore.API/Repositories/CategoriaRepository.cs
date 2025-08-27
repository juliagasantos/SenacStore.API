using Microsoft.EntityFrameworkCore;
using SenacStore.API.Data;
using SenacStore.API.Interfaces;
using SenacStore.API.Models;

namespace SenacStore.API.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly SenacStoreDbContext _senacStoreDbContext;
        public CategoriaRepository(SenacStoreDbContext senacStoreDbContext)
        {
            _senacStoreDbContext = senacStoreDbContext;
        }


        public async Task CreateCategoriaAsync(Categoria categoria)
        {
            await _senacStoreDbContext.Categorias.AddAsync(categoria);
            await _senacStoreDbContext.SaveChangesAsync();
        }

        public async Task DeleteCategoriaAsync(int id)
        {
           var categoria = await _senacStoreDbContext.Categorias.FindAsync(id);
           if(categoria != null)
            {
                _senacStoreDbContext.Categorias.Remove(categoria);
                _senacStoreDbContext.SaveChangesAsync();
            }
        }

        public async Task<List<Categoria>> GetAllAsync()
        {
            return await _senacStoreDbContext.Categorias.ToListAsync(); 
        }

        public async Task<Categoria> GetByIdAsync(int id)
        {
            return await _senacStoreDbContext.Categorias.FindAsync(id);
        }

        public async Task UpdateCategoriaAsync(Categoria categoria)
        {
           _senacStoreDbContext.Categorias.Update(categoria);
            await _senacStoreDbContext.SaveChangesAsync();
        }
    }
}
