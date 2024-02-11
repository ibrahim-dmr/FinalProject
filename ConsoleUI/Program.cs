﻿using Business.Concrete;
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
            //ProductTest();
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            foreach (var category in categoryManager.GetAll())
            {
                Console.WriteLine(category.CategoryName);
            }

        }

        private static void ProductTest()
        {
            ProductManager prodcutManager = new ProductManager(new EfProductDal());

            foreach (var product in prodcutManager.GetByUnitPrice(40, 100))
            {
                Console.WriteLine(product.ProductName);

            }
        }
    }
}
