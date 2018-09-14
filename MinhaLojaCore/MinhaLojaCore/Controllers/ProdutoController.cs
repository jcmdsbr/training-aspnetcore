using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinhaLojaCore.Context;
using MinhaLojaCore.Models;
using System;
using System.Linq;

namespace MinhaLojaCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : Controller
    {
        private readonly MinhaLojaContexto minhaLojaContexto;

        public ProdutoController(MinhaLojaContexto minhaLojaContexto)
        {
            this.minhaLojaContexto = minhaLojaContexto;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var produtos = minhaLojaContexto.Fabricantes.ToList();

            return Ok(produtos);
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var produto = minhaLojaContexto.Fabricantes.FirstOrDefault(x => x.Id == id);

            if (produto == null) return NoContent();

            return Ok(produto);
        }

        [HttpGet("{id}/categoria", Name = "GetCategoriaProduto")]
        public IActionResult GetCategoriaDoProduto(Guid id)
        {
        
            // select * from produto inner join categoria on produto.cd_categoria = categoria.id
            //          where produto.id = {id}

            //var categoria = _minhaLojaContexto.Produtos
            //    .Include(x => x.Categoria)
            //    .Select(x => x.Categoria); 
            // referencia ciclica = hasMany ,traz tabela de dominio

            //var categoria = _minhaLojaContexto.Produtos
            //    .Join(_minhaLojaContexto.Categorias, pt => pt.CategoriaId,
            //    cat => cat.Id, (pt, cat) => pt);


            //var categoria = from pt in _minhaLojaContexto.Produtos
            //                join cat in _minhaLojaContexto.Categorias on pt.CategoriaId equals cat.Id
            //                select new Produto { Categoria = cat, Id = pt.Id };
        
          
          
         // Select produtos join categoria where produtoId == id
            var produto = minhaLojaContexto.Produtos
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
            var produto = minhaLojaContexto.Produtos
                .Include(x => x.Fabricante)
                .FirstOrDefault(x => x.Id == id);

            if (produto == null) return NoContent();

            var fabricanteDoProduto = produto.Fabricante;

            return Ok(fabricanteDoProduto);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Produto produto)
        {
            // gera novo código
            produto.Id = Guid.NewGuid();

            // adiciona novo produto ao banco de dados
            minhaLojaContexto.Produtos.Add(produto);

            // salva alterações feitas. 
            minhaLojaContexto.SaveChanges();

            // retorna nova lista.
            return Ok(minhaLojaContexto.Produtos.ToList());
        }
    }
}
