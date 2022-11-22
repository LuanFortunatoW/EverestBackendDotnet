using AppModels.Customers;
using AutoMapper;
using DomainModels;

namespace AppServices.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile() 
        {
            CreateMap<CustomerCreate, Customer>();
            CreateMap<CustomerUpdate, Customer>();
            CreateMap<Customer, CustomerResult>();
        }
    }
}