using System.Data;
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

        public void Update(string codigo, string descricao, decimal preco, bool status, Guid departamentoId)
        {
            Codigo = codigo;
            Descricao = descricao;
            Preco = preco;
            Status = status;
            DepartamentoId = departamentoId;
        }

        public void Deletar()
        {
            Status = false;
        }

    }

}
