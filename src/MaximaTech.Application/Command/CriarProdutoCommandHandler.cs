using MaximaTech.api.Models;
using MaximaTech.core.Interfaces;

using MediatR;

namespace MaximaTech.Application.Command
{
    public class CriarProdutoCommandHandler : IRequestHandler<CriarProdutoCommand, Produtos>
    {
        private readonly IUnitOfWork _uow;

        public CriarProdutoCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public async Task<Produtos> Handle(CriarProdutoCommand request, CancellationToken cancellationToken)
        {
            await _uow.ProdutoRepository.AddAsync(request.Produtos);
            _uow.Save();
            return request.Produtos;
        }
    }
}
