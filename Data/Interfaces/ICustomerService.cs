﻿using Data.Entities;
using System.Collections.Generic;

namespace Data.Interfaces
{
    public interface ICustomerService
    {
        void Create(Customer customer);
        bool Update(Customer customer);
        bool Delete(long id);
        List<Customer> GetAll();
        Customer GetById(long id);
    }
}