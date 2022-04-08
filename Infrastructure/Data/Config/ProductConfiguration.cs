using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Core.Entities;

namespace Infrastructure.Data.Config
{
    public class ProductConfiguration:IEntityTypeConfiguration<Product>
    {
        public void Configure
        (Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Product> builder)
        {
          builder.Property(p=>p.Id).IsRequired();
          builder.Property(p=>p.Name).IsRequired().HasMaxLength(100);
          builder.Property(p=>p.Description).IsRequired().HasMaxLength(250);
          builder.Property(p=>p.Price).IsRequired().HasColumnType("decimal(18,2)");
          builder.Property(p=>p.PictureUrl).IsRequired();
          builder.HasOne(b=>b.ProductBrand).WithMany().HasForeignKey(p=>p.ProductBrandId);
           builder.HasOne(b=>b.ProductType).WithMany().HasForeignKey(p=>p.ProductTypeId);

        }
    }
}