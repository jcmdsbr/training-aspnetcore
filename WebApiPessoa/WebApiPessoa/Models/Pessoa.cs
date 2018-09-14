using System;
using System.ComponentModel.DataAnnotations;

namespace WebApiPessoa.Models
{
    public class Pessoa
    {
        public Pessoa()
        {
        }

        public Pessoa(int codigo, string cpf, string nome, DateTime dataDeNascimento)
        {
            Id = codigo;
            Cpf = cpf;
            Nome = nome;
            DataDeNascimento = dataDeNascimento;
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(14)]
        [MinLength(11)]
        public string Cpf { get; set; }

        [Required] [MinLength(3)] public string Nome { get; set; }

        [Required] public DateTime DataDeNascimento { get; set; }
    }
}