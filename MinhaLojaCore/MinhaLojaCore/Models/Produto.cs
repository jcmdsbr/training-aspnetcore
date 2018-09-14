using System;

namespace MinhaLojaCore.Models
{
    public class Produto
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public string Nome { get; set; }
        public DateTime DataDeFabricacao { get; set; }
        public Guid FabricanteId { get; set; }
        public Fabricante Fabricante { get; set; }
        public Guid CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
    }
}