using DTOService.DTOs.UrgencyDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.ValidationRules.ValidationRules
{
   public class UrgencyAddValidator:AbstractValidator<UrgencyAddDto>
    {
        public UrgencyAddValidator()
        {
            RuleFor(I => I.Definition).NotNull().WithMessage("Definition is required");
        }
    }
}
