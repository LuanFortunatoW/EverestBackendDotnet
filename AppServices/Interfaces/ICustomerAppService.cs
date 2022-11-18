using DomainModels;
using System.Collections.Generic;

namespace AppServices.Interfaces
{
    public interface ICustomerAppService 
    {
        void Create(Customer customer);
        void Update(Customer customer);
        void Delete(long id);
        IEnumerable<Customer> GetAll();
        Customer GetById(long id);
    }
}