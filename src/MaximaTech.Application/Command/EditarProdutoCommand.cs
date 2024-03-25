using MaximaTech.api.Models;

using MediatR;

namespace MaximaTech.Application.Command
{
    public class EditarProdutoCommand : IRequest<Produtos>
    {
        public Guid Id { get; set; }
        public string? Codigo { get; set; }
        public string? Descricao { get; set; }
        public decimal Preco { get; set; }
        public bool Status { get; set; }
        public Guid DepartamentoId { get; set; }

    }
}
