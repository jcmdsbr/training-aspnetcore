using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MinhaLojaCore.Context;
using MinhaLojaCore.Models;

namespace MinhaLojaCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FabricanteController : Controller
    {
        private readonly MinhaLojaContexto _minhaLojaContexto;

        public FabricanteController(MinhaLojaContexto minhaLojaContexto)
        {
            _minhaLojaContexto = minhaLojaContexto;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var fabricantes = _minhaLojaContexto.Fabricantes.ToList();

            return Ok(fabricantes);
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var fabricante = _minhaLojaContexto.Fabricantes.FirstOrDefault(x => x.Id == id);

            if (fabricante == null) return NoContent();

            return Ok(fabricante);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Fabricante fabricante)
        {
            // gera novo código
            fabricante.Id = Guid.NewGuid();

            // adiciona novo fabricante ao banco de dados
            _minhaLojaContexto.Fabricantes.Add(fabricante);

            // salva alterações feitas. 
            _minhaLojaContexto.SaveChanges();

            // retorna nova lista.
            return Ok(_minhaLojaContexto.Fabricantes.ToList());
        }
    }
}