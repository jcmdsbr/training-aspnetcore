using ApiAngular.Infra.Repository.Contracts;
using ApiAngular.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ApiAngular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private readonly IDocumentRepository _documentRepository;

        public DocumentController(IDocumentRepository documentRepository)
        {
            _documentRepository = documentRepository;
        }

        [HttpGet]
        public ActionResult<List<Document>> GetAll()
        {
            return _documentRepository.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Document> GetById(Guid id)
        {
            var document = _documentRepository.GetById(id);

            if (document == null)
                return NoContent();

            return document;
        }


        [HttpGet("search")]
        public ActionResult<List<Document>> GetByFilters(Guid? id, string description, string initials, int? status)
        {
            return _documentRepository.GetByFilters(id, description, initials, status);
        }

        [HttpPost]
        public IActionResult Post(Document document)
        {
            if (_documentRepository.GetBy(x => x.Initials == document.Initials) != null)
                return Conflict();

            _documentRepository.Add(document);

            _documentRepository.Commit();

            return Created($"api/document/{document.Id}", document);
        }

        [HttpPut]
        public IActionResult Put(Guid id, Document document)
        {
            if (_documentRepository.GetById(id) == null)
                return NoContent();

            _documentRepository.Update(document);

            _documentRepository.Commit();

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _documentRepository.Remove(id);

            _documentRepository.Commit();

            return Ok();
        }
    }
}