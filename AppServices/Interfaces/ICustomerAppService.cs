using DomainModels;
using DomainServices.Interfaces;

namespace AppServices.Interfaces
{
    internal interface ICustomerAppService : IAppService<ICustomerService, Customer>
    {
    }
}
