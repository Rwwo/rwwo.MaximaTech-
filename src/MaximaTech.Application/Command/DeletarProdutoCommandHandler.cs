using MaximaTech.api.Models;
using MaximaTech.core.Interfaces;

using MediatR;

namespace MaximaTech.Application.Command
{
    public class DeletarProdutoCommandHandler : IRequestHandler<DeletarProdutoCommand, Unit>
    {
        private readonly IUnitOfWork _uow;

        public DeletarProdutoCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public async Task<Unit> Handle(DeletarProdutoCommand request, CancellationToken cancellationToken)
        {
            var produto = await _uow.ProdutoRepository.GetByIdAsync(request.Id);

            produto.Deletar();

            await _uow.Save();

            return Unit.Value;
        }
    }
}
