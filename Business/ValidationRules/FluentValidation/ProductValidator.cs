using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator:AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(a => a.ProductName).NotEmpty().WithMessage("İsim alanı zorunludur");
            RuleFor(a => a.ProductName).MinimumLength(2).WithMessage("İsim alanı zorunludur");
            RuleFor(a => a.UnitPrice).NotEmpty();
            RuleFor(a => a.UnitPrice).GreaterThan(0);
            RuleFor(a => a.UnitPrice).GreaterThanOrEqualTo(10).When(p => p.CategoryId == 1); 

        }
    }
}
