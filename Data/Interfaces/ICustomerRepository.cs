using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    internal interface ICustomerRepository
    {
        void Create(Customer customer);
        bool Update(Customer customer);
        bool Delete(long  id);
        List<Customer> GetAll();
        Customer GetById(long id);
    }
}
