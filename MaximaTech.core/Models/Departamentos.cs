using System.ComponentModel.DataAnnotations.Schema;

using MediatR;

namespace MaximaTech.api.Models
{
    public class Departamentos : BaseEntity, IRequest<Departamentos>
    {

        public string Codigo { get; set; }
        public string Descricao { get; set; }

        //public virtual ICollection<Produtos> Produtos { get; set; }
    }
}
