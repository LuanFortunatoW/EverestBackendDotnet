using DomainModels;
using DomainServices.Interfaces;
using DomainServices.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : BaseController<ICustomerService, Customer>
    {
        public CustomerController(ICustomerService service) : base(service) { }
    }
}