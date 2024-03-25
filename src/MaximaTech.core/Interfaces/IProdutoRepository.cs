using MaximaTech.api.Models;

namespace MaximaTech.core.Interfaces
{
    public interface IProdutoRepository
    {
        Task<IEnumerable<Produtos>> GetAll();
        
        Task<Produtos> GetById(Guid Id);
        Task Add(Produtos produto);
    }
}
