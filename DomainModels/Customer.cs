﻿using System;

namespace DomainModels
{
    public class Customer : IModel
    {
        public Customer(
            string fullName,
            string email,
            string emailConfirmation,
            string cpf,
            string cellphone,
            DateTime dateOfBirth,
            bool emailSms,
            bool whatsapp,
            string country,
            string city,
            string postalCode,
            string address,
            int number
        )
        {
            FullName = fullName;
            Email = email;
            EmailConfirmation = emailConfirmation;
            Cpf = cpf.formatCpf();
            Cellphone = cellphone.formatCellphone();
            DateOfBirth = dateOfBirth;
            EmailSms = emailSms;
            Whatsapp = whatsapp;
            Country = country;
            City = city;
            PostalCode = postalCode.formatPostalCode();
            Address = address;
            Number = number;
        }
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string EmailConfirmation { get; set; }
        public string Cpf { get; set; }
        public string Cellphone { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool EmailSms { get; set; }
        public bool Whatsapp { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Address { get; set; }
        public int Number { get; set; }
        long IModel.Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}