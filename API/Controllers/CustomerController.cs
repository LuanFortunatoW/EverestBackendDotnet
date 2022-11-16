using DomainModels;
using DomainServices.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : BaseController<CustomerService, Customer>
    {
        public CustomerController(CustomerService service) : base(service) { }
    }
}