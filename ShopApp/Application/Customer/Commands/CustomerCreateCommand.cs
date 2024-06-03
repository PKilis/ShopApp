using Application.Interfaces;
using Domain.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Customer.Commands
{
    public class CustomerCreateCommand : IRequest<Customers>
    {
        public CustomerCreateCommand(string name, string email)
        {
            Name = name; 
            Email = email;
        }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<Address> Address { get; set; }
        public List<Orders> Orders { get; set; }


        public class Handler : IRequestHandler<CustomerCreateCommand, Customers>
        {
            private Mediator _mediator;
            private readonly IShopAppDbContext _dbContext;

            public Handler(Mediator mediator, IShopAppDbContext dbContext)
            {
                _mediator = mediator;
                _dbContext = dbContext;
            }

            public async Task<Customers> Handle(CustomerCreateCommand request, CancellationToken cancellationToken)
            {
                if (string.IsNullOrEmpty(request.Name))
                {
                    throw new Exception("CUSTOMER_NAME_CANNOT_BE_EMPTY");

                }
                if (string.IsNullOrEmpty(request.Email)) 
                {
                    throw new Exception("CUSTOMER_MAIL_CANNOT_BE_EMPTY");

                }

                var customer = new Customers
                {
                    Name = request.Name,
                    Email = request.Email,
                    Address = request.Address,
                    Orders = request.Orders,
                };

                await _dbContext.Customers.AddAsync(customer, cancellationToken);
                await _dbContext.SaveChangesAsync(cancellationToken);

                return customer;
            }
        }
    }
}
