using AppServices.Validators;
using DomainModels;
using DomainServices.Services;
using DomainServices.Interfaces;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AppServices.Interfaces;
using AppServices.Services;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ICustomerService, CustomerService>();
builder.Services.AddTransient<ICustomerAppService, CustomerAppService>();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddScoped<IValidator<Customer>, CustomerValidator>();
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