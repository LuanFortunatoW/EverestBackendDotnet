using AppModels.Customers;
using AppServices.Interfaces;
using AppServices.Services;
using AppServices.Validators;
using DomainModels;
using DomainServices.Interfaces;
using DomainServices.Services;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ICustomerService, CustomerService>();
builder.Services.AddTransient<ICustomerAppService, CustomerAppService>();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddScoped<IValidator<CustomerCreate>, CustomerCreateValidator>();
builder.Services.AddScoped<IValidator<CustomerUpdate>, CustomerUpdateValidator>();
builder.Services.AddAutoMapper(Assembly.Load(nameof(AppServices)));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();