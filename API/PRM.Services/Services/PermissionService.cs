using AutoMapper;
using FluentValidation;
using PRM.Bl.Dto;
using PRM.Model.Contexts.PRM;
using PRM.Model.Entities;
using PRM.Model.UnitOfWorks;
using PRM.Services.Generic;

namespace PRM.Services.Services.Example
{
    public interface IPermissionService : IEntityCRUDService<Permission, PermissionDto> {}

    public class PermissionService : EntityCRUDService<Permission, PermissionDto>, IPermissionService
    {
        public PermissionService(IMapper mapper, IUnitOfWork<IPRMDbContext> uow, IValidator<PermissionDto> validator) : base(mapper, uow, validator)
        {

        }
    }
}
