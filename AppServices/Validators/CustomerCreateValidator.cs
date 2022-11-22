using AppModels.Customers;
using FluentValidation;
using FluentValidation.Validators;
using System;
using static AppServices.Validators.StringValidator;

namespace AppServices.Validators
{
    public class CustomerCreateValidator : AbstractValidator<CustomerCreate>
    {
        public CustomerCreateValidator()
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
                .Must(IsValidCpf)
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
    }
}
