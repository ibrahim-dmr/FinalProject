using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;



namespace ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            ProductManager prodcutManager = new ProductManager(new EfProductDal());

            foreach (var product in prodcutManager.GetAllByCategoryId(2))
            {
                Console.WriteLine(product.ProductName);

            }
        }
    }
}
