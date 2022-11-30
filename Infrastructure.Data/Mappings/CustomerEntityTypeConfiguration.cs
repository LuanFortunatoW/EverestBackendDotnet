using DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Mappings
{
    public class CustomerEntityTypeConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");

            builder.HasKey(customer => customer.Id);

            builder.Property(customer => customer.Id)
                .ValueGeneratedOnAdd();

            builder.Property(c => c.FullName)
                .IsRequired()
                .HasColumnType("varchar(150)");

            builder.Property(c => c.Email)
                .IsRequired()
                .HasColumnType("varchar(150)");

            builder.Property(c => c.Cpf)
                .IsRequired()
                .HasColumnType("varchar(11)");

            builder.Property(c => c.Cellphone)
                .IsRequired()
                .HasColumnType("varchar(13)");

            builder.Property(c => c.DateOfBirth)
                .IsRequired()
                .HasColumnType("datetime");

            builder.Property(c => c.EmailSms)
                .IsRequired();

            builder.Property(c => c.Whatsapp)
                .IsRequired();

            builder.Property(c => c.Country)
               .IsRequired()
               .HasColumnType("varchar(50)");

            builder.Property(c => c.City)
               .IsRequired()
               .HasColumnType("varchar(50)");

            builder.Property(c => c.PostalCode)
               .IsRequired()
               .HasColumnType("varchar(10)");

            builder.Property(c => c.Address)
               .IsRequired()
               .HasColumnType("varchar(150)");

            builder.Property(c => c.Number)
               .IsRequired();
        }
    }
}