using DomainModels;
using DomainServices.Interfaces;

namespace AppServices.Interfaces
{
    public interface ICustomerAppService : IAppService<ICustomerService, Customer>
    {
    }
}
