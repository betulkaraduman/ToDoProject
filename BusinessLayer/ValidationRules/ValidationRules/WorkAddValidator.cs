using DTOService.DTOs.WorkDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.ValidationRules.ValidationRules
{
   public class WorkAddValidator:AbstractValidator<WorkAddDto>
    {
        public WorkAddValidator()
        {
            RuleFor(I => I.UrgencyId).ExclusiveBetween(1,int.MaxValue).WithMessage("Please select urgency state");
            RuleFor(I => I.Name).NotNull().WithMessage("Description is required");
        }
    }
}
