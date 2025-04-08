using FluentValidation;
using PRM.Bl.Dto;

namespace PRM.Bl.Validators
{
    public class PermissionTypeValidator : AbstractValidator<PermissionTypeDto>
    {
        public PermissionTypeValidator()
        {
            RuleFor(x => x.Description)
                .NotEmpty()
                    .WithMessage("Description is required");

        }
    }
}
