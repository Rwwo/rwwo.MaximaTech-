using System.Text.Json.Serialization;

namespace MaximaTech.api.Models
{
    public class Produtos : BaseEntity
    {

        public string? Codigo { get; set; }
        public string? Descricao { get; set; }
        public decimal Preco { get; set; }
        public bool Status { get; set; }

        public Guid DepartamentoId { get; set; }
        public virtual Departamentos? Departamento { get; set; }

    }

}
