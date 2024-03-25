using MaximaTech.api.Models;

namespace MaximaTech.core.Interfaces
{
    public interface IProdutoRepository
    {
        Task<IEnumerable<Produtos>> GetAllAsync();
        Task<Produtos> GetByIdAsync(Guid Id);
        Task AddAsync(Produtos produto);
    }
}
