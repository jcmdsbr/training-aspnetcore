using ApiAngular.Models.Fixed;
using System;
using System.ComponentModel.DataAnnotations;

namespace ApiAngular.Models
{
    public class Document : Entity
    {
        [Required] [MaxLength(20)] public string Initials { get; set; }

        [Required] [MaxLength(100)] public string Description { get; set; }

        public Status Status { get; set; }

        public Guid IdCustomer { get; set; }

        public Customer Customer { get; set; }
    }
}