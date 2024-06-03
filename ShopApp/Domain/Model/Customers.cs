using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Customers
    {
        public Customers()
        {
            //only db
        }

        private Customers(string name, string email, List<Address> address, List<Orders> orders)
        {

            Name = name;
            Email = email;
            Address = address;
            Orders = orders;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }  
        public virtual List<Address> Address { get; set; }
        public virtual List<Orders> Orders { get; set; }

       
    }
}
