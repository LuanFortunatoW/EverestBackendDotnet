using DomainModels;
using DomainServices.Interfaces;
using EntityFrameworkCore.UnitOfWork.Interfaces;
using Infrastructure.Data;
using System;
using System.Collections.Generic;

namespace DomainServices.Services
{
    public sealed class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepositoryFactory _repositoryFactory;

        public CustomerService(IUnitOfWork<EverestDBContext> unitOfWork, IRepositoryFactory<EverestDBContext> repositoryFactory)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _repositoryFactory = repositoryFactory ?? throw new ArgumentNullException(nameof(repositoryFactory));
        }

        public long Create(Customer customer)
        {
            var repository = _unitOfWork.Repository<Customer>();

            emailAlreadyExists(customer.Email, customer.Id);
            cpfAlreadyExists(customer.Cpf, customer.Id);

            repository.Add(customer);
            _unitOfWork.SaveChanges();

            return customer.Id;
        }

        public void Delete(long id)
        {
            var repository = _unitOfWork.Repository<Customer>();
            var customer = GetById(id);

            repository.Remove(customer);
            _unitOfWork.SaveChanges();
        }

        public IEnumerable<Customer> GetAll()
        {
            var repository = _repositoryFactory.Repository<Customer>();
            var query = repository.MultipleResultQuery();

            return repository.Search(query);
        }

        public Customer GetById(long id)
        {
            var repository = _repositoryFactory.Repository<Customer>();
            var query = repository.SingleResultQuery()
                                  .AndFilter(_customer => _customer.Id == id);
            var customer = repository.SingleOrDefault(query)
                ?? throw new ArgumentNullException($"Customer Id: {id} not found");

            return customer;
        }

        public void Update(Customer customer)
        {
            var repository = _unitOfWork.Repository<Customer>();

            GetById(customer.Id);

            emailAlreadyExists(customer.Email, customer.Id);
            cpfAlreadyExists(customer.Cpf, customer.Id);

            repository.Update(customer);
            _unitOfWork.SaveChanges();
        }

        private void emailAlreadyExists(string email, long id)
        {
            var repository = _repositoryFactory.Repository<Customer>();
            
            if (repository.Any(_customer => _customer.Email == email && _customer.Id != id))
                throw new ArgumentException("Email already exists");
        }
        private void cpfAlreadyExists(string cpf, long id)
        {
            var repository = _repositoryFactory.Repository<Customer>();

            if (repository.Any(_customer => _customer.Cpf == cpf && _customer.Id != id))
                throw new ArgumentException("Cpf already exists");
        }
    }
}