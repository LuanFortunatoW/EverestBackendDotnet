using AppServices.Interfaces;
using DomainModels;
using DomainServices.Interfaces;

namespace AppServices.Services
{
    public class CustomerAppService : BaseAppService<ICustomerService, Customer>, ICustomerAppService
    {
        public CustomerAppService(ICustomerService service) : base(service)
        {
        }
    }
}
