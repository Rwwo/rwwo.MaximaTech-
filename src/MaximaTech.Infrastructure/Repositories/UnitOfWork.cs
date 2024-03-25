using MaximaTech.core.Interfaces;
using MaximaTech.Infrastructure.Repositories;

namespace MaximaTech.api.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MaximaDbContext _dbContext;

        public UnitOfWork(MaximaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private IProdutoRepository _ProdutoRepository = null;
        public IProdutoRepository ProdutoRepository
        {
            get => _ProdutoRepository ?? (_ProdutoRepository = new ProdutoRepository(_dbContext));
        }



        public IDepartamentoRepository _DepartamentoRepository = null;
        public IDepartamentoRepository DepartamentoRepository
        {
            get => _DepartamentoRepository ?? (_DepartamentoRepository = new DepartamentoRepository(_dbContext));
        }

        public async Task Save()
        {
            await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
        }

    }


}
