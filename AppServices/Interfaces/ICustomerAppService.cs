using AppModels.Customers;
using DomainModels;
using System.Collections.Generic;

namespace AppServices.Interfaces
{
    public interface ICustomerAppService 
    {
        void Create(CustomerCreate customer);
        void Update(CustomerUpdate customer);
        void Delete(long id);
        IEnumerable<Customer> GetAll();
        Customer GetById(long id);
    }
}