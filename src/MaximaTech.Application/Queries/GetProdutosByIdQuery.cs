using MaximaTech.api.Models;

using MediatR;

namespace MaximaTech.Application.Queries
{
    public class GetProdutosByIdQuery : IRequest<Produtos>
    {
        public Guid Id { get; }
        public GetProdutosByIdQuery(Guid id)
        {
            Id = id;
        }
    }

}
