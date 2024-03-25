using MediatR;

namespace MaximaTech.api.Models
{
    public class ProdutoViewModel : IRequest<Produtos>
    {
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public bool Status { get; set; }
        public Guid DepartamentoId { get; set; }
    }

}
