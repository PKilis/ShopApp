using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Address
    {
        public int Id {  get; set; }    
        public string Name { get; set; }
        public string City { get; set; }   
        public string District { get; set; }
        public Customer Customer { get; set; }

        
        
    }
}
