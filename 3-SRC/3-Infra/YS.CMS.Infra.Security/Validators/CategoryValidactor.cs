﻿using FluentValidation;
using YS.CMS.Common.Models;

namespace YS.CMS.Infra.Security.Validators
{
    public class CategoryValidactor : AbstractValidator<CategoryViewModel>
    {
        public CategoryValidactor()
        {
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.CreateUser).NotEmpty();
        }
    }
}
