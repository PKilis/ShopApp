using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Infrastructure.Persistence
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customers>
    {
        public void Configure(EntityTypeBuilder<Customers> builder)
        {
            builder.ToTable("customer");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id").HasColumnType("int");
            builder.Property(x => x.Name).HasColumnName("name").HasColumnType("varchar(60)");
            builder.Property(x => x.Email).HasColumnName("email").HasColumnType("varchar(80)");

        }
    }
}
