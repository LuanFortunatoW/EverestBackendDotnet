using Data.Entities;
using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly List<Customer> _customers = new();

        public void Create(Customer createdCustomer)
        {
            bool emailAlreadyExists = _customers.Any(customer => customer.Email == createdCustomer.Email);
            if (emailAlreadyExists)
            {
                throw new ArgumentException("Email already exists");
            }

            bool cpfAlreadyExists = _customers.Any(customer => customer.Cpf == createdCustomer.Cpf);
            if (cpfAlreadyExists)
            {
                throw new ArgumentException("Cpf already exists");
            }

            createdCustomer.Id = _customers.LastOrDefault()?.Id + 1 ?? 1; 

            _customers.Add(createdCustomer);
        }

        public bool Delete(long id)
        {
            Customer customer = GetById(id);

            return _customers.Remove(customer);
        }

        public List<Customer> GetAll()
        {

            return _customers;
        }

        public Customer GetById(long id)
        {
            var result = _customers.FirstOrDefault(customer => customer.Id == id);

            if (result is null)
            {
                throw new ArgumentException($"Customer with id {id} not found");
            }

            return result;
        }

        public bool Update(Customer updatedCustomer)
        {
            bool emailAlreadyExists = _customers.Any(customer => customer.Email == updatedCustomer.Email && customer.Id != updatedCustomer.Id);
            if (emailAlreadyExists)
            {
                throw new ArgumentException("Email already exists");
            }

            bool cpfAlreadyExists = _customers.Any(customer => customer.Cpf == updatedCustomer.Cpf && customer.Id != updatedCustomer.Id);
            if (cpfAlreadyExists)
            {
                throw new ArgumentException("Cpf already exists");
            }

            int index = _customers.FindIndex(customer => customer.Id == updatedCustomer.Id);

            if (index == -1) return false;
            
            updatedCustomer.Id = _customers[index].Id;
            _customers[index] =  updatedCustomer;
            return true;
        }
    }
}
