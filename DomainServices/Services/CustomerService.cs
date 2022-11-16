using DomainModels;
using DomainServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DomainServices.Services
{
    public class CustomerService : BaseService<Customer>
    {
        private readonly List<Customer> _customers = new();

        override
        public void Create(Customer createdCustomer)
        {
            bool emailAlreadyExists = _customers.Any(customer => customer.Email == createdCustomer.Email);
            if (emailAlreadyExists)
                throw new ArgumentException("Email already exists");

            bool cpfAlreadyExists = _customers.Any(customer => customer.Cpf == createdCustomer.Cpf);
            if (cpfAlreadyExists)
                throw new ArgumentException("Cpf already exists");

            base.Create(createdCustomer);
        }

        override
        public bool Update(Customer updatedCustomer)
        {
            bool emailAlreadyExists = _customers.Any(customer => customer.Email == updatedCustomer.Email && customer.Id != updatedCustomer.Id);
            if (emailAlreadyExists)
                throw new ArgumentException("Email already exists");

            bool cpfAlreadyExists = _customers.Any(customer => customer.Cpf == updatedCustomer.Cpf && customer.Id != updatedCustomer.Id);
            if (cpfAlreadyExists)
                throw new ArgumentException("Cpf already exists");

            return base.Update(updatedCustomer);
        }
    }
}


