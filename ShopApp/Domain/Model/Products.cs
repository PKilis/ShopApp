using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Products
    {
        public Products()
        {
            // only db
        }
        private Products(string name, string description, double price, double quantity)
        {
            ProductName = name;
            Description = description;
            Price = price;
            CreatedDate = DateTime.Now;
            Quantity = quantity;
        }

        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public DateTime CreatedDate { get; set; }
        public double Quantity { get; set; }
        public virtual List<Orders> Orders { get; set; }

        public static Products Create(string name, string description, double price, double quantity)
        {
            return new Products(name, description, price, quantity);
        }
    }
}
