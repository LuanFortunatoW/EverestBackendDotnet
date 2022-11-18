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

        public virtual void Create(Customer customer)
        {
            var emailAlreadyExists = _customers.Any(_customer => _customer.Email == customer.Email);
            if (emailAlreadyExists)
                throw new ArgumentException("Email already exists");

            var cpfAlreadyExists = _customers.Any(_customer => _customer.Cpf == customer.Cpf);
            if (cpfAlreadyExists)
                throw new ArgumentException("Cpf already exists");

            customer.Id = _customers.LastOrDefault()?.Id + 1 ?? 1;

            _customers.Add(customer);
        }

        public virtual void Delete(long id)
        {
            Customer customer = GetById(id);

            _customers.Remove(customer);
        }

        public virtual IEnumerable<Customer> GetAll()
        {
            return _customers;
        }

        public virtual Customer GetById(long id)
        {
            var result = _customers.FirstOrDefault(_customer => _customer.Id == id)
                ?? throw new ArgumentNullException($"Customer Id: {id} not found");

            return result;
        }

        public virtual void Update(Customer customer)
        {
            var index = _customers.FindIndex(_customer => _customer.Id == customer.Id);
            if (index == -1)
                throw new ArgumentNullException($"Customer Id: {customer.Id} not found");

            _customers[index] = customer;
        }
    }
}