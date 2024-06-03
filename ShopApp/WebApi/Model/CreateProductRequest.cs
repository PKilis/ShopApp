using Domain.Model;
using System.Xml.Linq;


namespace WebApi.Model
{
    public class CreateProductRequest
    {

        public string ProductName { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }


        /*public ProductCreateCommand ToCommand()
        {
            return new ProductCreateCommand
            (
             Name, Description, Price, Quantity
            );
        }*/
    }
}
