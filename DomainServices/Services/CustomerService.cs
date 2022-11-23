using DomainModels;
using DomainServices.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DomainServices.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly EverestDBContext _dBContext;

        public CustomerService(EverestDBContext dBContext)
        {
            _dBContext = dBContext ?? throw new ArgumentNullException(nameof(dBContext));
        }

        public long Create(Customer customer)
        {
            var _dbSet = _dBContext.Set<Customer>();

            if (_dbSet.Any(_customer => _customer.Email == customer.Email))
                throw new ArgumentException("Email already exists");

            if (_dbSet.Any(_customer => _customer.Cpf == customer.Cpf))
                throw new ArgumentException("Cpf already exists");

            _dbSet.Add(customer);
            _dBContext.SaveChanges();

            return customer.Id;
        }

        public void Delete(long id)
        {
            var customer = GetById(id);

            _dBContext.Entry(customer).State = EntityState.Deleted;
            _dBContext.SaveChanges();
        }

        public IEnumerable<Customer> GetAll()
        {
            return _dBContext.Set<Customer>().ToList();
        }

        public Customer GetById(long id)
        {
            var result = _dBContext.Set<Customer>().FirstOrDefault(_customer => _customer.Id == id)
                ?? throw new ArgumentNullException($"Customer Id: {id} not found");

            return result;
        }

        public void Update(Customer customer)
        {
            var _customer = GetById(customer.Id);

            _dBContext.Entry(_customer).State = EntityState.Modified;
            _dBContext.SaveChanges();
        }
    }
}