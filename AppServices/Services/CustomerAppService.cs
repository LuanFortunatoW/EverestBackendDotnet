using AppServices.Interfaces;
using DomainModels;
using DomainServices.Interfaces;
using System;
using System.Collections.Generic;

namespace AppServices.Services
{
    public class CustomerAppService : ICustomerAppService
    {
        private readonly ICustomerService _service;
        public CustomerAppService(ICustomerService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        public void Create(Customer customer)
        {
            _service.Create(customer);
        }

        public void Delete(long id)
        {
            _service.Delete(id);
        }

        public IEnumerable<Customer> GetAll()
        {
            return _service.GetAll();
        }

        public Customer GetById(long id)
        {
            return _service.GetById(id);
        }

        public void Update(Customer customer)
        {
            _service.Update(customer);
        }
    }
}