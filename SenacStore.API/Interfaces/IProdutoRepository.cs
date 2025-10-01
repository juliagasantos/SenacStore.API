using SenacStore.API.Models;

namespace SenacStore.API.Interfaces
{
    public interface IProdutoRepository
    {
        Task CreateProdutoAsync(Produto pruduto);
        Task<List<Produto>> GetAllAsync();
        Task<Produto> GetByIdAsync(int id);
        Task<List<Produto>> GetByCategoryAsync(int categoryId);
        Task UpdateProdutoAsync(Produto produto);
        Task DeleteProdutoAsync(int id);

    }
}
