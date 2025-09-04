using Microsoft.EntityFrameworkCore;
using SenacStore.API.Data;
using SenacStore.API.Interfaces;
using SenacStore.API.Models;

namespace SenacStore.API.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly SenacStoreDbContext _senacStoreDbContext;

        public UsuarioRepository(SenacStoreDbContext senacStoreDbContext)
        {
            _senacStoreDbContext = senacStoreDbContext;
        }

        public async Task CreateUsuarioAsync(Usuario usuario)
        {
            await _senacStoreDbContext.Usuarios.AddAsync(usuario);
            await _senacStoreDbContext.SaveChangesAsync();
        }

        public async Task DeleteUsuarioAsync(int id)
        {
            var usuario = await _senacStoreDbContext.Usuarios.FindAsync(id);
            if (usuario != null)
            {
                _senacStoreDbContext.Usuarios.Remove(usuario);
                await _senacStoreDbContext.SaveChangesAsync();
            }
        }

        public async Task<List<Usuario>> GetAllAsync()
        {
            return await _senacStoreDbContext.Usuarios.ToListAsync();
        }

        public async Task<Usuario> GetByIdAsync(int id)
        {
            return await _senacStoreDbContext.Usuarios.FindAsync(id);
        }

        public async Task UpdateUsuarioAsync(Usuario usuario)
        {
            _senacStoreDbContext.Usuarios.Update(usuario);
            await _senacStoreDbContext.SaveChangesAsync();
        }
        public async Task<Usuario> GetByLoginAsync(string email, string senha)
        {
            return await _senacStoreDbContext.Usuarios.FirstOrDefaultAsync(u => u.Email == email && u.Senha == senha);
        }
    }
}
