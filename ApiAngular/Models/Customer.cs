using System.ComponentModel.DataAnnotations;

namespace ApiAngular.Models
{
    public class Customer : Entity
    {
        [Required] [MaxLength(100)] public string Name { get; set; }
    }
}