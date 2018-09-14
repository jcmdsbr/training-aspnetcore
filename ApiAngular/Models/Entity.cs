using System;

namespace ApiAngular.Models
{
    public abstract class Entity
    {
        public virtual Guid Id { get; set; }
    }
}