using FluentValidation;
using PRM.Bl.Dto;

namespace PRM.Bl.Validators
{
    public class PermissionValidator : AbstractValidator<PermissionDto>
    {
        public PermissionValidator()
        {
            RuleFor(x => x.EmployeeFirstName)
                .NotEmpty()
                    .WithMessage("El campo Nombre es obligatorio");


            RuleFor(x => x.EmployeeLastName)
               .NotEmpty()
                   .WithMessage("El campo Apellido es obligatorio");


            RuleFor(x => x.PermissionTypeId)
               .NotEmpty()
                   .WithMessage("El campo Tipo Permiso es obligatorio");


            RuleFor(x => x.PermissionDate)
               .NotEmpty()
                   .WithMessage("El campoFecha de solicitud de permiso es obligatorio");

        }
    }
}
