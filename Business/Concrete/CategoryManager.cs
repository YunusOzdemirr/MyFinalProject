using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public IDataResult<List<Category>> GetAll()
        {
            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll().ToList());
        }

        public IDataResult<Category> GetById(int categoryId)
        {
            var result = _categoryDal.Get(p => p.CategoryId == categoryId);
            return new SuccessDataResult<Category>(result);
        }
        public IResult Add(Category category)
        {
                _categoryDal.Add(category);
                return new SuccessResult(Messages.ProductAdded);
            // ValidationTool.Validate(new ProductValidator(), product);

            //    _logger.Log();
            // return new ErrorResult(ex.ToString());
        }
    }
}
