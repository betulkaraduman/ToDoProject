using DTOService.DTOs.AppUserDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.ValidationRules.ValidationRules
{
   public class AppUserLoginValidator:AbstractValidator<LoginDto>
    {
        public AppUserLoginValidator()
        {
            RuleFor(I => I.Username).NotNull().WithMessage("Username is required");
            RuleFor(I => I.Password).NotNull().WithMessage("Password is required");
        }
    }
}
