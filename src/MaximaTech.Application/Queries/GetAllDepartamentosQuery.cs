using MaximaTech.api.Models;

using MediatR;

namespace MaximaTech.Application.Queries
{
    public class GetAllDepartamentosQuery : IRequest<List<Departamentos>>
    {
    }
}
