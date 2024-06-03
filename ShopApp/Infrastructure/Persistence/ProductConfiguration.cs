using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence
{
    public class ProductConfiguration : IEntityTypeConfiguration<Products>
    {
        public void Configure(EntityTypeBuilder<Products> builder)
        {
            builder.ToTable("products");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id").HasColumnType("int");
            builder.Property(x => x.ProductName).HasColumnName("product_name").HasColumnType("varchar(30)");
            builder.Property(x => x.Description).HasColumnName("description").HasColumnType("varchar(60)");
            builder.Property(x => x.Price).HasColumnName("price").HasColumnType("float");
            builder.Property(x => x.CreatedDate).HasColumnName("created_date").HasColumnType("date");
            builder.Property(x => x.Quantity).HasColumnName("quantity").HasColumnType("int");

            
        }
    }
}
