using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Data.Entities;
using Data.Repositories;
using Data.Interfaces;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _repository;

        public CustomerController(ICustomerRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var result = _repository.GetAll();
                return Ok(result);
            }
            catch (ArgumentException exception)
            {
                var message = exception.InnerException?.Message ?? exception.Message;
                return BadRequest(message);
            }

        }

        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            try
            {
                var result = _repository.GetById(id);
                return Ok(result);
            }
            catch (ArgumentException exception)
            {
                var message = exception.InnerException?.Message ?? exception.Message;
                return NotFound(message);
            }
        }

        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            try
            {
                _repository.Create(customer);
                return Created("", customer.Id);
            }
            catch (ArgumentException exception)
            {
                var message = exception.InnerException?.Message ?? exception.Message;
                return BadRequest(message);
            }
        }

        [HttpDelete]
        public IActionResult Delete(long id)
        {
            try
            {
                var result = _repository.Delete(id);
                return Ok();
            }
            catch (ArgumentException exception)
            {
                var message = exception.InnerException?.Message ?? exception.Message;
                return NotFound(message);
            }
        }

        [HttpPut]
        public virtual IActionResult Update(Customer customer)
        {
            try
            {
                var result = _repository.Update(customer);
                return result ? Ok() : NotFound();
            }
            catch (ArgumentException exception)
            {
                var message = exception.InnerException?.Message ?? exception.Message;
                return NotFound(message);
            }

        }
    }

}
