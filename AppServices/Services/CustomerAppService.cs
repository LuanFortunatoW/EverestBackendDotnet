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

        public long Create(CustomerCreate customer)
        {
            var _mappedCustomer = _mapper.Map<Customer>(customer);
            return _service.Create(_mappedCustomer);
        }

        public void Delete(long id)
        {
            _service.Delete(id);
        }

        public IEnumerable<CustomerResult> GetAll()
        {
            var customers = _service.GetAll();
            var mappedCustomers = _mapper.Map<IEnumerable<CustomerResult>>(customers);
            return mappedCustomers;
        }

        public CustomerResult GetById(long id)
        {
            var customer = _service.GetById(id);
            var mappedCustomer = _mapper.Map<CustomerResult>(customer);
            return mappedCustomer;
        }

        public void Update(long id, CustomerUpdate customer)
        {
            var _mappedCustomer = _mapper.Map<Customer>(customer);
            _mappedCustomer.Id = id;
            _service.Update(_mappedCustomer);
        }
    }
}