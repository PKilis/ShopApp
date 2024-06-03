using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Domain.Model;

namespace Application.Interfaces
{
    public interface IShopAppDbContext
    {
        DbSet<Customers> Customers { get; set; }
        DbSet<Address> Address { get; set; }
        DbSet<Products> Products { get; set; }
        DbSet<Orders> Orders { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
