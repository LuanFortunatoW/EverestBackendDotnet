using AppServices.Interfaces;
using DomainModels;
using DomainServices.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<A, S, T> : ControllerBase where A : IAppService<S, T> where S : IService<T> where T : BaseModel
    {
        private readonly A _appService;

        public BaseController(A appService)
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
        public virtual IActionResult Create(T model)
        {
            try
            {
                _appService.Create(model);
                return Created("Id: ", model.Id);
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
        public virtual IActionResult Update(T model)
        {
            try
            {
                _appService.Update(model);
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