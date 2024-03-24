using System.ComponentModel.DataAnnotations;

namespace MaximaTech.api.Models
{
    public abstract partial class BaseEntity
    {
        public Guid Id { get; set; }
    }
}
