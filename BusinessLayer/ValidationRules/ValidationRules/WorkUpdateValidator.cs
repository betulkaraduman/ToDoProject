using DTOService.DTOs.WorkDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.ValidationRules.ValidationRules
{
   public class WorkUpdateValidator : AbstractValidator<WorkUpdateDto>
    {
        public WorkUpdateValidator()
        {
            RuleFor(I => I.UrgencyId).ExclusiveBetween(0, int.MaxValue).WithMessage("Please select urgency state");
            RuleFor(I => I.Name).NotNull().WithMessage("Description is required");
        }
    }
}
