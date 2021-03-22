using ClkTeknoloji.Server.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClkTeknoloji.Server.Data.Context.Configurations
{
    public class ServiceConfiguration : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.ToTable("Services");

            builder.HasOne(i => i.Product)
                .WithOne(i => i.Service)
                .HasForeignKey<Product>(i => i.ServiceId)
                .HasConstraintName("product_service_id_fk");
        }
    }
}
