﻿using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
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
            ProductTest();
            //CategoryTest();

        }

        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            foreach (var category in categoryManager.GetAll().Data)
            {
                Console.WriteLine(category.CategoryName);
            }
        }

        private static void ProductTest()
        {
            ProductManager prodcutManager = new ProductManager(new EfProductDal(), new CategoryManager(new EfCategoryDal()));

            var result = prodcutManager.GetProductDetails();
            if(result.Success == true ) 
            {
                foreach (var product in result.Data)
                {
                    Console.WriteLine(product.ProductNama + "/" + product.CategoryName);

                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
           
        }
    }
}
