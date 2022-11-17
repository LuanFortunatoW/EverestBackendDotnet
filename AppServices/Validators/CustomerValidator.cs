using DomainModels;
using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Linq;

namespace AppServices.Validators
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(customer => customer.FullName)
                .NotEmpty()
                .MinimumLength(5);

            RuleFor(customer => customer.Email)
                .NotEmpty()
                .Equal(costumer => costumer.EmailConfirmation)
                .WithMessage("Emails don't match")
                .EmailAddress(EmailValidationMode.AspNetCoreCompatible)
                .WithMessage("Email is not valid");

            RuleFor(customer => customer.Cpf)
                .NotEmpty()
                .Must(isValidCpf)
                .WithMessage("Cpf is not valid.");

            RuleFor(customer => customer.Cellphone)
                .NotEmpty()
                .MinimumLength(8);

            RuleFor(customer => customer.DateOfBirth)
                .NotEmpty()
                .WithMessage("Date of birth is not valid.");

            RuleFor(customer => customer.DateOfBirth.AddYears(18))
                .LessThan(DateTime.Now)
                .WithMessage("Age must be over 18.");

            RuleFor(customer => customer.EmailSms)
                .NotNull();

            RuleFor(customer => customer.Whatsapp)
                .NotNull();

            RuleFor(customer => customer.Country)
                .NotEmpty();

            RuleFor(customer => customer.City)
                .NotEmpty();

            RuleFor(customer => customer.PostalCode)
                .NotEmpty();

            RuleFor(customer => customer.Address)
                .NotEmpty()
                .MinimumLength(4);

            RuleFor(customer => customer.Number)
                .NotEmpty();
        }

        public bool isValidCpf(string cpf)
        {
            if (cpf.Length != 11)
                return false;

            if (cpf.All(x => x == cpf.First()))
                return false;

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