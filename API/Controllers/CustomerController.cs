using DomainModels;
using DomainServices.Interfaces;
using DomainServices.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : BaseController<CustomerService, Customer>
    {
        public CustomerController(CustomerService service) : base(service)
        {
        }
    }

}
