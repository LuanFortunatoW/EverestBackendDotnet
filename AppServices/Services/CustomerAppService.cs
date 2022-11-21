using AppModels.Customers;
using AppServices.Interfaces;
using AutoMapper;
using DomainModels;
using DomainServices.Interfaces;
using System;
using System.Collections.Generic;

namespace AppServices.Services
{
    public class CustomerAppService : ICustomerAppService
    {
        private readonly ICustomerService _service;
        private readonly IMapper _mapper;
        public CustomerAppService(ICustomerService service, IMapper mapper)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public void Create(CustomerCreate customer)
        {
            Customer _mappedCustomer = _mapper.Map<Customer>(customer);
            _service.Create(_mappedCustomer);
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

        public void Update(CustomerUpdate customer)
        {
            Customer _mappedCustomer = _mapper.Map<Customer>(customer);
            _service.Update(_mappedCustomer);
        }
    }
}