using DTOService.DTOs.AppUserDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.ValidationRules.ValidationRules
{
   public class AppUserAddValidator:AbstractValidator<RegisterDto>
    {
        public AppUserAddValidator()
        {
            RuleFor(I => I.Username).NotNull().WithMessage("Username is required");
            RuleFor(I => I.Name).NotNull().WithMessage("Name is required");
            RuleFor(I => I.Surname).NotNull().WithMessage("Surname is required");
            RuleFor(I => I.Email).NotNull().WithMessage("Email is required");
            RuleFor(I => I.Password).NotNull().WithMessage("Password is required");
            RuleFor(I => I.ConfirmPassword).NotNull().WithMessage("ConfirmPassword is required");
            RuleFor(I => I.ConfirmPassword).Equal(I=>I.Password).WithMessage("ConfirmPassword must equal Password");
        }
    }
}
