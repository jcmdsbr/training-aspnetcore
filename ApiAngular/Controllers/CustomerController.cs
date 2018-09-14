using ApiAngular.Infra.Repository.Contracts;
using ApiAngular.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ApiAngular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet]
        public ActionResult<List<Customer>> GetAll()
        {
            return _customerRepository.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Customer> GetById(Guid id)
        {
            var document = _customerRepository.GetById(id);

            if (document == null)
                return NoContent();

            return document;
        }

        [HttpPost]
        public IActionResult Post(Customer document)
        {
            if (_customerRepository.GetBy(x => x.Name == document.Name) != null)
                return Conflict();

            _customerRepository.Add(document);

            _customerRepository.Commit();

            return Created($"api/document/{document.Id}", document);
        }

        [HttpPut]
        public IActionResult Put(Guid id, Customer document)
        {
            if (_customerRepository.GetById(id) == null)
                return NoContent();

            _customerRepository.Update(document);

            _customerRepository.Commit();

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _customerRepository.Remove(id);

            _customerRepository.Commit();

            return Ok();
        }
    }
}