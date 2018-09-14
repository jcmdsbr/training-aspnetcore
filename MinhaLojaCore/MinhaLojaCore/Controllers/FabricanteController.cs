using Microsoft.AspNetCore.Mvc;
using MinhaLojaCore.Context;
using MinhaLojaCore.Models;
using System;
using System.Linq;

namespace MinhaLojaCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FabricanteController : Controller
    {
        private readonly MinhaLojaContexto minhaLojaContexto;

        public FabricanteController(MinhaLojaContexto minhaLojaContexto)
        {
            this.minhaLojaContexto = minhaLojaContexto;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var fabricantes = minhaLojaContexto.Fabricantes.ToList();

            return Ok(fabricantes);
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var fabricante = minhaLojaContexto.Fabricantes.FirstOrDefault(x => x.Id == id);

            if (fabricante == null) return NoContent();

            return Ok(fabricante);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Fabricante fabricante)
        {
            // gera novo código
            fabricante.Id = Guid.NewGuid();

            // adiciona novo fabricante ao banco de dados
            minhaLojaContexto.Fabricantes.Add(fabricante);

            // salva alterações feitas. 
            minhaLojaContexto.SaveChanges();

            // retorna nova lista.
            return Ok(minhaLojaContexto.Fabricantes.ToList());
        }
    }
}