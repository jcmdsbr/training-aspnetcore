using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MinhaLojaCore.Context;

namespace MinhaLojaCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : Controller
    {
        private readonly MinhaLojaContexto _minhaLojaContexto;

        public CategoriaController(MinhaLojaContexto minhaLojaContexto)
        {
            _minhaLojaContexto = minhaLojaContexto;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var categorias = _minhaLojaContexto.Categorias.ToList();

            return Ok(categorias);
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var categoria = _minhaLojaContexto.Categorias.FirstOrDefault(x => x.Id == id);

            if (categoria == null) return NoContent();

            return Ok(categoria);
        }
    }
}