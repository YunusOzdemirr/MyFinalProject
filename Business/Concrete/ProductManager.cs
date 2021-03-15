using Business.Abstract;
using Business.BusinessAscpects.Autofac;
using Business.CCS;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        ICategoryService _categoryService;
        //ILogger _logger;

        public ProductManager(IProductDal productDal,ICategoryService categoryService)
        {
            _productDal = productDal;
            _categoryService = categoryService;
            //  _logger = logger;
        }
        [SecuredOperation("product.add,admin")]
        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
            //business codes
            //validation
            // _logger.Log();
            //IResult yerine Result da gelebilir
           IResult result =BusinessRules.Run(CheckIfProductCountOfCategoryCorrect(product.CategoryId),
               CheckIfProductNameExistCorrect(product.ProductName), CheckIfCategoryCount());

            if (result!=null)
            {
                return result;
            }
            else
            {
                _productDal.Add(product);
                return new SuccessResult(Messages.ProductAdded);
            }
            // ValidationTool.Validate(new ProductValidator(), product);

            //    _logger.Log();
            // return new ErrorResult(ex.ToString());
        }

        public IDataResult<List<Product>> GetAll()
        {
            //İş kodları
            if (DateTime.Now.Hour == 18)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }
            return new DataResult<List<Product>>(_productDal.GetAll(), true, Messages.ProductList);

        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id), Messages.ProductList);
        }

        public IDataResult<Product> GetById(int productId)
        {
            var result = _productDal.Get(p => p.ProductId == productId);
            return new SuccessDataResult<Product>(result, Messages.ProductList);
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            var result = _productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max);
            return new SuccessDataResult<List<Product>>(result, Messages.ProductList);
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            if (DateTime.Now.Hour == 18)
            {
                return new ErrorDataResult<List<ProductDetailDto>>(Messages.MaintenanceTime);
            }
            var result = _productDal.GetProductDetails();
            return new SuccessDataResult<List<ProductDetailDto>>(result, Messages.ProductList);
        }

        [ValidationAspect(typeof(ProductValidator))]
        public IResult Update(Product product)
        {
            if (CheckIfProductCountOfCategoryCorrect(product.CategoryId).Success)
            {
                _productDal.Update(product);
                return new SuccessResult(Messages.ProductAdded);
            }
            return new ErrorResult();
        }
        private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)
        {
            var result = _productDal.GetAll(p => p.CategoryId == categoryId);
            if (result.Count > 10)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }
            return new SuccessResult();
        }
        private IResult CheckIfProductNameExistCorrect(string productName)
        {
            var result = _productDal.GetAll(p => p.ProductName == productName).Any();
            if (result)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExists);
            }
            return new SuccessResult();
        }
        private IResult CheckIfCategoryCount()
        {
            var result = _categoryService.GetAll();
            if (result.Data.Count==15)
            {
                return new ErrorResult(Messages.CategoryLimitExceded);
            }
            return new SuccessResult();
        }
        
    }
}
