using DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Mappings
{
    public class CustomerEntityTypeConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customer");

            builder.HasKey(customer => customer.Id);

            builder.Property(customer => customer.Id)
                .ValueGeneratedOnAdd();

            builder.Property(customer => customer.Id)
                .HasColumnName("Id");

            builder
                .Property(c => c.FullName)
                .IsRequired();
        }
    }
}
