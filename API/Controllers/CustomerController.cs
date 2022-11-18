using AppServices.Interfaces;
using DomainModels;
using DomainServices.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : BaseController<ICustomerAppService, ICustomerService, Customer>
    {
        public CustomerController(ICustomerAppService appService) : base(appService) { }
    }
}