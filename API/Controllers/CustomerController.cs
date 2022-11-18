using AppServices.Interfaces;
using DomainModels;
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
        public virtual IActionResult Get()
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
        public virtual IActionResult GetById(long id)
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
        public virtual IActionResult Create(Customer customer)
        {
            try
            {
                _appService.Create(customer);
                return Created("Id: ", customer.Id);
            }
            catch (ArgumentException exception)
            {
                var message = exception.InnerException?.Message ?? exception.Message;
                return BadRequest(message);
            }
        }

        [HttpDelete]
        public virtual IActionResult Delete(long id)
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

        [HttpPut]
        public virtual IActionResult Update(Customer customer)
        {
            try
            {
                _appService.Update(customer);
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