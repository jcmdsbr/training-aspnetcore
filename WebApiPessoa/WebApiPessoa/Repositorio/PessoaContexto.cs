using System;
using System.Collections.Generic;
using System.Linq;
using WebApiPessoa.Models;

namespace WebApiPessoa.Repositorio
{
    public static class PessoaContexto
    {
        private static readonly List<Pessoa> _pessoas = new List<Pessoa>
        {
            new Pessoa(1, "444.222.098-25", "FelipãoDev", DateTime.Now),
            new Pessoa(2, "444.222.999-25", "ClaudinhaDev", DateTime.Now),
            new Pessoa(3, "444.222.198-25", "RonaldinhoDev", DateTime.Now),
            new Pessoa(4, "444.222.294-29", "DilminhaDev", DateTime.Now)
        };

        public static void Add(Pessoa pessoa)
        {
            var codigo = 0;

            if (_pessoas != null && _pessoas.Any())
                codigo = _pessoas.LastOrDefault().Id;

            pessoa.Id = ++codigo;

            _pessoas.Add(pessoa);
        }

        public static void Remove(Pessoa pessoa)
        {
            _pessoas.Remove(pessoa);
        }

        public static bool Update(Predicate<Pessoa> expressao, Pessoa pessoa)
        {
            var index = _pessoas.FindIndex(expressao);


            if (index >= 0)
            {
                _pessoas[index] = pessoa;
                return true;
            }

            return false;
        }

        public static List<Pessoa> ConsultarTodos()
        {
            return _pessoas;
        }

        public static Pessoa ConsultarPor(Func<Pessoa, bool> expressao)
        {
            return _pessoas.FirstOrDefault(expressao);
        }
    }
}