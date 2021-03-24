using ClkTeknoloji.Server.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClkTeknoloji.Server.Data.Context.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.ToTable("Customers");

            builder.HasMany(i => i.Products)
            .WithOne(i => i.Customer)
            .HasForeignKey(i => i.CustomerId)
            .HasConstraintName("product_customer_id_fk");

        }
    }
}
