using DomainModels;
using DomainServices.Interfaces;
using System;
using System.Collections.Generic;

namespace AppServices.Services
{
    public class CustomerAppService 
    {
        private readonly ICustomerService _service;
        public CustomerAppService(ICustomerService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        public virtual void Create(Customer customer)
        {
            _service.Create(customer);
        }

        public virtual void Delete(long id)
        {
            _service.Delete(id);
        }

        public virtual IEnumerable<Customer> GetAll()
        {
            return _service.GetAll();
        }

        public virtual Customer GetById(long id)
        {
            return _service.GetById(id);
        }

        public virtual void Update(Customer customer)
        {
            _service.Update(customer);
        }
    }
}