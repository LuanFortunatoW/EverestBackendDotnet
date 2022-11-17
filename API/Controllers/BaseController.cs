using DomainModels;
using DomainServices.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<S, T> : ControllerBase where S : IService<T> where T : BaseModel
    {
        private readonly S _service;

        public BaseController(S service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var result = _service.GetAll();
                return Ok(result);
            }
            catch 
            {
                return NotFound();
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            try
            {
                var result = _service.GetById(id);
                return Ok(result);
            }
            catch (ArgumentNullException exception)
            {
                var message = exception.InnerException?.Message ?? exception.Message;
                return NotFound(message);
            }
        }

        [HttpPost]
        public IActionResult Create(T model)
        {
            try
            {
                _service.Create(model);
                return Created("Id: ", model.Id);
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
                _service.Delete(id);
                return NoContent();
            }
            catch (ArgumentException exception)
            {
                var message = exception.InnerException?.Message ?? exception.Message;
                return NotFound(message);
            }
        }

        [HttpPut]
        public virtual IActionResult Update(T model)
        {
            try
            {
                _service.Update(model);
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