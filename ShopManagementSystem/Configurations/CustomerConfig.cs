using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagementSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagementSystem.Configurations
{
    internal class CustomerConfig : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(x=>x.CustomerName)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(x => x.Gender)
                  .IsRequired()
                  .HasMaxLength(10);

            builder.Property(x => x.PhoneNumber)
                  .IsRequired()
                  .HasMaxLength(20);
        }
    }
}
