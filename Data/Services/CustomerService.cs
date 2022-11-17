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

        public void Create(Customer createdCustomer)
        {
            var emailAlreadyExists = _customers.Any(customer => customer.Email == createdCustomer.Email);
            if (emailAlreadyExists)
                throw new ArgumentException("Email already exists");

            var cpfAlreadyExists = _customers.Any(customer => customer.Cpf == createdCustomer.Cpf);
            if (cpfAlreadyExists)
                throw new ArgumentException("Cpf already exists");


            createdCustomer.Id = _customers.LastOrDefault()?.Id + 1 ?? 1;

            _customers.Add(createdCustomer);
        }

        public void Delete(long id)
        {
            var customer = GetById(id);
            _customers.Remove(customer);
        }

        public IEnumerable<Customer> GetAll()
        {
            return _customers;
        }

        public Customer GetById(long id)
        {
            var result = _customers.FirstOrDefault(customer => customer.Id == id);
            if (result is null)
                throw new ArgumentNullException($"Customer with id {id} not found");

            return result;
        }

        public void Update(Customer updatedCustomer)
        {
            var index = _customers.FindIndex(customer => customer.Id == updatedCustomer.Id);
            if (index == -1)
                throw new ArgumentNullException($"Customer with id {updatedCustomer.Id} not found");

            var emailAlreadyExists = _customers.Any(customer => customer.Email == updatedCustomer.Email && customer.Id != updatedCustomer.Id);
            if (emailAlreadyExists)
                throw new ArgumentException("Email already exists");

            var cpfAlreadyExists = _customers.Any(customer => customer.Cpf == updatedCustomer.Cpf && customer.Id != updatedCustomer.Id);
            if (cpfAlreadyExists)
                throw new ArgumentException("Cpf already exists");

            _customers[index] = updatedCustomer;
        }
    }
}