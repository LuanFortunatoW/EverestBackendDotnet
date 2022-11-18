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
        public void Update(Customer customer)
        {
            var emailAlreadyExists = _customers.Any(_customer => _customer.Email == customer.Email && _customer.Id != customer.Id);
            if (emailAlreadyExists)
                throw new ArgumentException("Email already exists");

            var cpfAlreadyExists = _customers.Any(_customer => _customer.Cpf == customer.Cpf && _customer.Id != customer.Id);
            if (cpfAlreadyExists)
                throw new ArgumentException("Cpf already exists");

            var index = _customers.FindIndex(_customer => _customer.Id == customer.Id);
            if (index == -1)
                throw new ArgumentNullException($"Customer Id: {customer.Id} not found");

            _customers[index] = customer;
        }

        override
        public Customer GetById(long id)
        {
            var result = _customers.FirstOrDefault(customer => customer.Id == id)
                ?? throw new ArgumentNullException($"Customer Id: {id} not found");

            return result;
        }
    }
}