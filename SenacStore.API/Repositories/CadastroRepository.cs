using Microsoft.EntityFrameworkCore;
using SenacStore.API.Data;
using SenacStore.API.Interfaces;
using SenacStore.API.Models;

namespace SenacStore.API.Repositories
{
    public class CadastroRepository : ICadastroRepository
    {
        private readonly SenacStoreDbContext _senacStoreDbContext;
        public CadastroRepository(SenacStoreDbContext senacStoreDbContext)
        {
            _senacStoreDbContext = senacStoreDbContext;
        }
        public async Task CreateCadastroAsync(Cadastro cadastro)
        {
            await _senacStoreDbContext.Cadastros.AddAsync(cadastro);
            await _senacStoreDbContext.SaveChangesAsync();
        }

        public async Task DeleteCadastroAsync(int id)
        {
            var cadastro = await _senacStoreDbContext.Cadastros.FindAsync(id);
            if (cadastro != null)
            {
                _senacStoreDbContext.Cadastros.Remove(cadastro);
                _senacStoreDbContext.SaveChangesAsync();
            }
        }

        public async Task<List<Cadastro>> GetAllAsync()
        {
           return await _senacStoreDbContext.Cadastros.ToListAsync();
        }

        public async Task<Cadastro> GetByIdAsync(int id)
        {
            return await _senacStoreDbContext.Cadastros.FindAsync(id);
        }

        public async Task UpdateCadastroAsync(Cadastro cadastro)
        {
            _senacStoreDbContext.Cadastros.Update(cadastro);
            await _senacStoreDbContext.SaveChangesAsync();
        }
    }
}
