using Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Managar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string data_source = "data source=srv2\\pupils;initial catalog=Shop_Ado_Net;Integrated Security=SSPI;Persist Security Info=False;TrustServerCertificate=true";
            Product product = new Product();
            Category category = new Category();
            Console.WriteLine(category.InsertCategory(data_source));
            Console.WriteLine(product.InsertProduct(data_source));
            product.getProducts(data_source);
        }
    }
}
