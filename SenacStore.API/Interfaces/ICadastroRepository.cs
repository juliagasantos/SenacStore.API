using SenacStore.API.Models;

namespace SenacStore.API.Interfaces
{
    public interface ICadastroRepository
    {
        Task CreateCadastroAsync(Cadastro cadastro);
        Task<List<Cadastro>> GetAllAsync();
        Task<Cadastro> GetByIdAsync(int id);
        Task UpdateCadastroAsync(Cadastro cadastro);
        Task DeleteCadastroAsync(int id);
    }
}
