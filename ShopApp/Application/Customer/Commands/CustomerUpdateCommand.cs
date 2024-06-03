using Application.Product.Commands;
using Domain.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Customer.Commands
{
    public class CustomerUpdateCommand : IRequest<Customers>
    {
        public CustomerUpdateCommand(string name, string email)
        {
            Name = name;
            Email = email;
        }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<Address> Address { get; set; }
        public List<Orders> Orders { get; set; }


        /*   public class Handler : IRequestHandler<CustomerUpdateCommand, Customers>
           {
               public Task<Customers> Handle(CustomerUpdateCommand request, CancellationToken cancellationToken)
               {
                   throw new NotImplementedException();
               }
           }*/
    }
}

