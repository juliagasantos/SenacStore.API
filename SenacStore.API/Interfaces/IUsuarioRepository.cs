using SenacStore.API.Models;

namespace SenacStore.API.Interfaces
{
    public interface IUsuarioRepository
    {
        Task CreateUsuarioAsync(Usuario usuario);
        Task<List<Usuario>> GetAllAsync();
        Task<Usuario> GetByIdAsync(int id);
        Task UpdateUsuarioAsync(Usuario usuario);
        Task DeleteUsuarioAsync(int id);

        Task<Usuario> GetByLoginAsync(string email, string senha);
    }
}
