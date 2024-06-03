using Application.Interfaces;
using Domain.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace Application.Product.Commands
{
    public class ProductCreateCommand :IRequest<Products>
    {
        public ProductCreateCommand(string name, string description, double price, int quantity)
        {
            ProductName = name;
            Description = description;
            Price = price;
            Quantity = quantity;
        }

        public string ProductName { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }


        public class Handler : IRequestHandler<ProductCreateCommand, Products>
        {
            private IMediator _mediator;
            private readonly IShopAppDbContext _dbContext;

            public Handler(IShopAppDbContext dbContext, IMediator mediator)
            {
                _mediator = mediator;
                _dbContext = dbContext;
            }

            public async Task<Products> Handle(ProductCreateCommand request, CancellationToken cancellationToken)
            {
                if (string.IsNullOrEmpty(request.ProductName))
                {
                    throw new Exception("PRODUCT_NAME_CANNOT_BE_EMPTY");
                }

                var product = Products.Create(request.ProductName, request.Description, request.Price, request.Quantity);
                await _dbContext.Products.AddAsync(product, cancellationToken);
                await _dbContext.SaveChangesAsync(cancellationToken);
                return product;
            }
        }
    }
}
