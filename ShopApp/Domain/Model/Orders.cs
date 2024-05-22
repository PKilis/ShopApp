using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Orders
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public Customer Customer { get; set; }
        public Address Address { get; set; }
        public virtual List<Products> Products { get; set; }
    }
}
}
