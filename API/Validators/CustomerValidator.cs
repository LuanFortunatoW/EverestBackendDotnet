using Data.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Validators
{
    internal class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(customer => customer.FullName)
                .NotNull()
                .MinimumLength(5);

            RuleFor(customer => customer.Email)
                .NotEmpty()
                .Equal(costumer => costumer.EmailConfirmation)
                .WithMessage("Emails don't match")
                .Matches(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")
                .WithMessage("Email is not valid");

            RuleFor(customer => customer.Cpf)
                .NotEmpty()
                .Must(BeValidCpf)
                .WithMessage("Cpf is not valid.");

            RuleFor(customer => customer.Cellphone)
                .NotNull();

            RuleFor(customer => customer.DateOfBirth)
                .NotNull()
                .LessThan(DateTime.Now.Date)
                .WithMessage("Date of birth is not valid.");

            RuleFor(customer => customer.EmailSms)
                .NotNull();

            RuleFor(customer => customer.Whatsapp)
                .NotNull();

            RuleFor(customer => customer.Country)
                .NotNull();

            RuleFor(customer => customer.City)
                .NotNull();

            RuleFor(customer => customer.PostalCode)
                .NotNull();

            RuleFor(customer => customer.Address)
                .NotNull();

            RuleFor(customer => customer.Number)
                .NotNull();
        }

        public bool BeValidCpf(string cpf)
        {
            if (cpf.Length != 11)
            {
                return false;
            }

            int[] multiplier1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplier2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digit;
            int sum;
            int rest;

            tempCpf = cpf.Substring(0, 9);
            sum = 0;

            for (int i = 0; i < 9; i++)
                sum += int.Parse(tempCpf[i].ToString()) * multiplier1[i];

            rest = sum % 11;

            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;

            digit = rest.ToString();

            tempCpf = tempCpf + digit;

            sum = 0;
            for (int i = 0; i < 10; i++)
                sum += int.Parse(tempCpf[i].ToString()) * multiplier2[i];

            rest = sum % 11;
            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;

            digit = digit + rest.ToString();

            return cpf.EndsWith(digit);
        }
    }
}
