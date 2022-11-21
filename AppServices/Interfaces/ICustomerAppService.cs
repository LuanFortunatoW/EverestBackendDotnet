using AppModels.Customers;
using System.Collections.Generic;

namespace AppServices.Interfaces
{
    public interface ICustomerAppService 
    {
        void Create(CustomerCreate customer);
        void Update(CustomerUpdate customer);
        void Delete(long id);
        IEnumerable<CustomerResult> GetAll();
        CustomerResult GetById(long id);
    }
}