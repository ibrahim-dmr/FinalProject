using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal __productDal;

        public ProductManager(IProductDal productDal)
        {
            __productDal = productDal;
        }

        public IResult Add(Product product)
        {
            __productDal.Add(product);
            return new Result(true,"Ürün eklendi");
        }

        public List<Product> GetAll()
        {
            return __productDal.GetAll();
        }

        public List<Product> GetAllByCategoryId(int id)
        {
            return __productDal.GetAll(p=>p.CategoryId==id);
        }

        public Product GetById(int productId)
        {
            return __productDal.Get(p=>p.ProductId == productId);
        }

        public List<Product> GetByUnitPrice(decimal min, decimal max)
        {
            return __productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max);
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            return __productDal.GetProductDetails();
        }
    }
}
