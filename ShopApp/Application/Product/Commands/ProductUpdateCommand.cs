using Application.Interfaces;
using Domain.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Product.Commands
{
    public class ProductUpdateCommand : IRequest<Products>
    {
        public ProductUpdateCommand(int id, string name, string description, double price, int quantity)
        {
            ProductId = id;
            ProductName = name;
            Description = description;
            Price = price;
            Quantity = quantity;
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        public class Handler : IRequestHandler<ProductUpdateCommand, Products>
        {
            private IMediator _mediator;
            private readonly IShopAppDbContext _dbContext;

            public Handler(IShopAppDbContext dbContext, IMediator mediator)
            {
                _mediator = mediator;
                _dbContext = dbContext;
            }

            public async Task<Products> Handle(ProductUpdateCommand request, CancellationToken cancellationToken)
            {
                if (string.IsNullOrEmpty(request.ProductName))
                {
                    throw new Exception("PRODUCT_NAME_CANNOT_BE_EMPTY");
                }

                var product = await _dbContext.Products.FindAsync(new object[] { request.ProductId }, cancellationToken);

                if (product == null)
                {
                    throw new Exception("PRODUCT_NOT_FOUND");
                }

                // Ürün özelliklerini güncelle
                product.ProductName = request.ProductName;
                product.Description = request.Description;
                product.Price = request.Price;
                product.Quantity = request.Quantity;

                // Değişiklikleri veritabanına kaydetme
                _dbContext.Products.Update(product);
                await _dbContext.SaveChangesAsync(cancellationToken);

                return product;
            }
        }
    }
}
