using SenacStore.API.Models;

namespace SenacStore.API.Interfaces
{
    public interface ICategoriaRepository
    {
        Task CreateCategoriaAsync(Categoria categoria);
        Task<List<Categoria>> GetAllAsync();
        Task<Categoria> GetByIdAsync(int id);
        Task UpdateCategoriaAsync(Categoria categoria);
        Task DeleteCategoriaAsync(int id);
    }
}
