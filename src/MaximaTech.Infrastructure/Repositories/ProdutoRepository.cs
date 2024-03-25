using MaximaTech.api.Data;
using MaximaTech.api.Models;
using MaximaTech.core.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace MaximaTech.Infrastructure.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        protected readonly MaximaDbContext _dbContext;
        public ProdutoRepository(MaximaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddAsync(Produtos produto)
        {
            await _dbContext.Produtos.AddAsync(produto);
        }

        public async Task<IEnumerable<Produtos>> GetAllAsync()
        {
            return await _dbContext.Produtos.Include(p => p.Departamento).ToListAsync();
        }

        public async Task<Produtos> GetByIdAsync(Guid Id)
        {
            return await _dbContext.Produtos.Include(p => p.Departamento).FirstOrDefaultAsync(t => t.Id == Id);
        }
    }
}
