using Data.Entities;
using Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService ?? throw new ArgumentNullException(nameof(customerService));
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var result = _customerService.GetAll();
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
                var result = _customerService.GetById(id);
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
                _customerService.Create(customer);
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
                _customerService.Delete(id);
                return NoContent();
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
                _customerService.Update(customer);
                return Ok("Customer updated");
            }
            catch (ArgumentNullException exception)
            {
                var message = exception.InnerException?.Message ?? exception.Message;
                return NotFound(message);
            }
            catch (ArgumentException exception)
            {
                var message = exception.InnerException?.Message ?? exception.Message;
                return BadRequest(message);
            }
        }
    }
}