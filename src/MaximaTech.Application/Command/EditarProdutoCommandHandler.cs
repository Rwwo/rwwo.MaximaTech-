using MaximaTech.api.Models;
using MaximaTech.core.Interfaces;

using MediatR;

namespace MaximaTech.Application.Command
{
    public class EditarProdutoCommandHandler : IRequestHandler<EditarProdutoCommand, Produtos>
    {
        private readonly IUnitOfWork _uow;

        public EditarProdutoCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public async Task<Produtos> Handle(EditarProdutoCommand request, CancellationToken cancellationToken)
        {
            var produto = await _uow.ProdutoRepository.GetByIdAsync(request.Id);

            produto.Update(request.Codigo, request.Descricao, request.Preco, request.Status, request.DepartamentoId);

            await _uow.Save();

            return produto;
        }
    }
}
