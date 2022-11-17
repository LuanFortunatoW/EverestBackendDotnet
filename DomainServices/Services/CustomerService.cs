using DomainModels;
using DomainServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DomainServices.Services
{
    public class CustomerService : BaseService<Customer>, ICustomerService
    {
        private readonly List<Customer> _customers = new();

        override
        public void Create(Customer createdCustomer)
        {
            var emailAlreadyExists = _customers.Any(customer => customer.Email == createdCustomer.Email);
            if (emailAlreadyExists)
                throw new ArgumentException("Email already exists");

            var cpfAlreadyExists = _customers.Any(customer => customer.Cpf == createdCustomer.Cpf);
            if (cpfAlreadyExists)
                throw new ArgumentException("Cpf already exists");

            base.Create(createdCustomer);
        }

        override
        public void Update(Customer updatedCustomer)
        {
            var emailAlreadyExists = _customers.Any(customer => customer.Email == updatedCustomer.Email && customer.Id != updatedCustomer.Id);
            if (emailAlreadyExists)
                throw new ArgumentException("Email already exists");

            var cpfAlreadyExists = _customers.Any(customer => customer.Cpf == updatedCustomer.Cpf && customer.Id != updatedCustomer.Id);
            if (cpfAlreadyExists)
                throw new ArgumentException("Cpf already exists");

            base.Update(updatedCustomer);
        }
    }
}