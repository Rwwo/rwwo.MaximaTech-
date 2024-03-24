using MaximaTech.api.Models;

using MediatR;

namespace MaximaTech.Application.Queries
{
    public class GetAllProdutosQuery : IRequest<List<Produtos>>
    {
    }
}
