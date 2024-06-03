using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("address");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id").HasColumnType("int");
            builder.Property(x => x.City).HasColumnName("city").HasColumnType("varchar(30)");
            builder.Property(x => x.District).HasColumnName("district").HasColumnType("varchar(30)");

            builder.HasOne(x => x.Customer).WithMany(x => x.Address);

        }
    }
}
