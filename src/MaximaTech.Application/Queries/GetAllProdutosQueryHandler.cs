using MaximaTech.api.Models;
using MaximaTech.core.Interfaces;

using MediatR;

namespace MaximaTech.Application.Queries
{
    public class GetAllProdutosQueryHandler : IRequestHandler<GetAllProdutosQuery, List<Produtos>>
    {
        private readonly IUnitOfWork _uow;
        public GetAllProdutosQueryHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public async Task<List<Produtos>> Handle(GetAllProdutosQuery request, CancellationToken cancellationToken)
        {
            var departamentos = await _uow.ProdutoRepository.GetAllAsync();

            return departamentos.ToList();
        }
    }
}
