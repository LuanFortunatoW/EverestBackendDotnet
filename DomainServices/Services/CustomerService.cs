using DomainModels;
using DomainServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DomainServices.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly List<Customer> _customers = new();

        public long Create(Customer customer)
        {
            if (_customers.Any(_customer => _customer.Email == customer.Email))
                throw new ArgumentException("Email already exists");

            if (_customers.Any(_customer => _customer.Cpf == customer.Cpf))
                throw new ArgumentException("Cpf already exists");

            customer.Id = _customers.LastOrDefault()?.Id + 1 ?? 1;

            _customers.Add(customer);

            return customer.Id;
        }

        public void Delete(long id)
        {
            Customer customer = GetById(id);

            _customers.Remove(customer);
        }

        public IEnumerable<Customer> GetAll()
        {
            return _customers;
        }

        public Customer GetById(long id)
        {
            var result = _customers.FirstOrDefault(_customer => _customer.Id == id)
                ?? throw new ArgumentNullException($"Customer Id: {id} not found");

            return result;
        }

        public void Update(Customer customer)
        {
            var index = _customers.FindIndex(_customer => _customer.Id == customer.Id);
            if (index == -1)
                throw new ArgumentNullException($"Customer Id: {customer.Id} not found");

            _customers[index] = customer;
        }
    }
}