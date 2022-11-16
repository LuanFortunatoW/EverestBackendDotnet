﻿using Data.Entities;
using System.Collections.Generic;

namespace Data.Interfaces
{
    public interface ICustomerService
    {
        void Create(Customer customer);
        void Update(Customer customer);
        void Delete(long id);
        List<Customer> GetAll();
        Customer GetById(long id);
    }
}
