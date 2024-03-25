namespace MaximaTech.core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IProdutoRepository ProdutoRepository { get; }
        IDepartamentoRepository DepartamentoRepository { get; }
        int Save();
    }
}
