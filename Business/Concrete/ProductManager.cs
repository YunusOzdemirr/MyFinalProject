using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public IResult Add(Product product)
        {
            //business codes
            //validation
            var context = new ValidationContext<Product>(product);
            ProductValidator productValidator = new ProductValidator();
            var result = productValidator.Validate(context);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
              _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);

        }

        public IDataResult<List<Product>> GetAll()
        {
            //İş kodları
            if (DateTime.Now.Hour==18)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }
            return new DataResult<List<Product>>(_productDal.GetAll(),true,Messages.ProductList);

        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id), Messages.ProductList);
        }

        public IDataResult<Product> GetById(int productId)
        {
            var result = _productDal.Get(p => p.ProductId == productId);
            return new SuccessDataResult<Product>(result,Messages.ProductList);
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            var result= _productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max);
            return new SuccessDataResult<List<Product>>(result,Messages.ProductList);
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            if (DateTime.Now.Hour == 18)
            {
                return new ErrorDataResult<List<ProductDetailDto>>(Messages.MaintenanceTime);
            }
            var result = _productDal.GetProductDetails();
            return new SuccessDataResult<List<ProductDetailDto>>(result,Messages.ProductList);
        }
    }
}
