using MaximaTech.api.Models;

namespace MaximaTech.core.Interfaces
{
    public interface IDepartamentoRepository
    {
        Task<IEnumerable<Departamentos>> GetAll();
    }
}
