using MaximaTech.api.Models;
using MaximaTech.core.Interfaces;

using MediatR;

namespace MaximaTech.Application.Queries
{
    public class GetAllDepartamentosQueryHandler : IRequestHandler<GetAllDepartamentosQuery, List<Departamentos>>
    {
        private readonly IUnitOfWork _uow;
        public GetAllDepartamentosQueryHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public async Task<List<Departamentos>> Handle(GetAllDepartamentosQuery request, CancellationToken cancellationToken)
        {
            var departamentos = await _uow.DepartamentoRepository.GetAll();

            return departamentos.ToList();
        }
    }
}
