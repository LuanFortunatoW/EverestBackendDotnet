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
            RuleFor(customer => customer.FullName).NotNull().MinimumLength(5);
            RuleFor(customer => customer.Email)
                .NotEmpty()
                .Equal(costumer => costumer.EmailConfirmation)
                .WithMessage("Emails don't match")
                .Matches(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")
                .WithMessage("Email is not valid");

            RuleFor(costumer => costumer.Cpf)
                .NotEmpty()
                .MinimumLength(11)
                .Must(BeValidCpf)
                .WithMessage("Cpf is not valid.");

            RuleFor(costumer => costumer.Cellphone)
                .NotNull();

            RuleFor(costumer => costumer.Country)
                .NotNull();

            RuleFor(costumer => costumer.City)
                .NotNull();

            RuleFor(costumer => costumer.PostalCode)
                .NotNull();

            RuleFor(costumer => costumer.DateOfBirth)
                .NotNull()
                .LessThan(DateTime.Now.Date);

        }

        public bool BeValidCpf(string cpf)
        {
            int[] multiplier1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplier2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string digit;
            int sum;
            int rest;

            sum = 0;

            for (int i = 0; i < 9; i++)
                sum += int.Parse(cpf[i].ToString()) * multiplier1[i];

            rest = sum % 11;

            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;

            digit = rest.ToString();

            sum = 0;
            for (int i = 0; i < 10; i++)
                sum += int.Parse(cpf[i].ToString()) * multiplier2[i];

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
