using MaximaTech.api.Models;
using MaximaTech.core.Interfaces;

using MediatR;

namespace MaximaTech.Application.Queries
{
    public class GetProdutosByIdQueryHandler : IRequestHandler<GetProdutosByIdQuery, Produtos>
    {
        private readonly IUnitOfWork _uow;
        public GetProdutosByIdQueryHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public async Task<Produtos> Handle(GetProdutosByIdQuery request, CancellationToken cancellationToken)
        {
            var Produto = await _uow.ProdutoRepository.GetByIdAsync(request.Id);

            return Produto;
        }
    }

}
