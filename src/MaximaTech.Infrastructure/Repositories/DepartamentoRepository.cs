using MaximaTech.api.Data;
using MaximaTech.api.Models;
using MaximaTech.core.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace MaximaTech.Infrastructure.Repositories
{
    public class DepartamentoRepository : IDepartamentoRepository
    {
        protected readonly MaximaDbContext _dbContext;
        public DepartamentoRepository(MaximaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Departamentos>> GetAll()
        {
            return await _dbContext
                .Departamentos
                //.Include(t=>t.Produtos)
                .ToListAsync();
        }
    }
}
