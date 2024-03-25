using MaximaTech.api.Models;

using MediatR;

namespace MaximaTech.Application.Command
{
    public class DeletarProdutoCommand : IRequest<Unit>
    {
        public DeletarProdutoCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}
