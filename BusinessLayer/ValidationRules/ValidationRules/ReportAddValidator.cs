using DTOService.DTOs.ReportDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.ValidationRules.ValidationRules
{
    public class ReportAddValidator : AbstractValidator<ReportAddDto>
    {
        public ReportAddValidator()
        {
            RuleFor(I => I.Definition).NotNull().WithMessage("Definition is required");
            RuleFor(I => I.Detail).NotNull().WithMessage("Definition is required");
        }

    }
}
