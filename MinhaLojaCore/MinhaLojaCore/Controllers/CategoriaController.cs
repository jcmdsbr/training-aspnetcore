using Microsoft.AspNetCore.Mvc;
using MinhaLojaCore.Context;
using System;
using System.Linq;

namespace MinhaLojaCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : Controller
    {
        private readonly MinhaLojaContexto minhaLojaContexto;

        public CategoriaController(MinhaLojaContexto minhaLojaContexto)
        {
            this.minhaLojaContexto = minhaLojaContexto;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var categorias = minhaLojaContexto.Categorias.ToList();

            return Ok(categorias);
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var categoria = minhaLojaContexto.Categorias.FirstOrDefault(x => x.Id == id);

            if (categoria == null) return NoContent();

            return Ok(categoria);
        }
    }
}