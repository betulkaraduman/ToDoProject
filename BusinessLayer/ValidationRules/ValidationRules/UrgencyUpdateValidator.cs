using DTOService.DTOs.UrgencyDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.ValidationRules.ValidationRules
{
   public class UrgencyUpdateValidator:AbstractValidator<UrgencyUpdateDto>
    {
        public UrgencyUpdateValidator()
        {
            RuleFor(I => I.Definition).NotNull().WithMessage("Definition is required");
        }
    }
}
