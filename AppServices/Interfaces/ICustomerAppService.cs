using AppModels.Customers;
using System.Collections.Generic;

namespace AppServices.Interfaces
{
    public interface ICustomerAppService 
    {
        long Create(CustomerCreate customer);
        void Update(long id, CustomerUpdate customer);
        void Delete(long id);
        IEnumerable<CustomerResult> GetAll();
        CustomerResult GetById(long id);
    }
}