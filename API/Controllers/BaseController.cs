using DomainModels;
using DomainServices.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<S, T> : ControllerBase where S : BaseService<T> where T : BaseModel
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
                var result = _service.GetById(id);
                return Ok(result);
            }
            catch (ArgumentException exception)
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
                return Created("", model.Id);
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
                var result = _service.Delete(id);
                return Ok();
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
                var result = _service.Update(model);
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