using AppModels.Customers;
using AppServices.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerAppService _appService;

        public CustomerController(ICustomerAppService appService)
        {
            _appService = appService ?? throw new ArgumentNullException(nameof(appService));
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var result = _appService.GetAll();
                return Ok(result);
            }
            catch
            {
                return NoContent();
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            try
            {
                var result = _appService.GetById(id);
                return Ok(result);
            }
            catch (ArgumentNullException exception)
            {
                var message = exception.InnerException?.Message ?? exception.Message;
                return NotFound(message);
            }
        }

        [HttpPost]
        public IActionResult Create(CustomerCreate customer)
        {
            try
            {
                _appService.Create(customer);
                return Created("Customer: ", customer);
            }
            catch (ArgumentException exception)
            {
                var message = exception.InnerException?.Message ?? exception.Message;
                return BadRequest(message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            try
            {
                _appService.Delete(id);
                return NoContent();
            }
            catch (ArgumentException exception)
            {
                var message = exception.InnerException?.Message ?? exception.Message;
                return NotFound(message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] CustomerUpdate customer)
        {
            try
            {
                _appService.Update(id, customer);
                return Ok();
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