using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinhaLojaCore.Context;
using MinhaLojaCore.Models;

namespace MinhaLojaCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : Controller
    {
        private readonly MinhaLojaContexto _minhaLojaContexto;

        public ProdutoController(MinhaLojaContexto minhaLojaContexto)
        {
            _minhaLojaContexto = minhaLojaContexto;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var produtos = _minhaLojaContexto.Fabricantes.ToList();

            return Ok(produtos);
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var produto = _minhaLojaContexto.Fabricantes.FirstOrDefault(x => x.Id == id);

            if (produto == null) return NoContent();

            return Ok(produto);
        }

        [HttpGet("{id}/categoria", Name = "GetCategoriaProduto")]
        public IActionResult GetCategoriaDoProduto(Guid id)
        {
            var produto = _minhaLojaContexto.Produtos
                .Include(x => x.Categoria)
                .FirstOrDefault(x => x.Id == id);

            if (produto == null) return NoContent();

            var categoriaDoProduto = produto.Categoria;

            return Ok(categoriaDoProduto);
        }

        [HttpGet("{id}/fabricante", Name = "GetFabricanteProduto")]
        public IActionResult GetFabricanteDoProduto(Guid id)
        {
            // Select produtos join fabricante where produtoId == id
            var produto = _minhaLojaContexto.Produtos
                .Include(x => x.Fabricante)
                .FirstOrDefault(x => x.Id == id);

            if (produto == null) return NoContent();

            var fabricanteDoProduto = produto.Fabricante;

            return Ok(fabricanteDoProduto);
        }

        [HttpPost]
        public IActionResult Post(Produto produto)
        {
            // gera novo código
            produto.Id = Guid.NewGuid();

            // adiciona novo produto ao banco de dados
            _minhaLojaContexto.Produtos.Add(produto);

            // salva alterações feitas. 
            _minhaLojaContexto.SaveChanges();

            // retorna nova lista.
            return Ok(_minhaLojaContexto.Produtos.ToList());
        }
    }
}