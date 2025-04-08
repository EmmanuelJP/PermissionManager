using AutoMapper;
using FluentValidation;
using PRM.Bl.Dto;
using PRM.Model.Contexts.PRM;
using PRM.Model.Entities;
using PRM.Model.UnitOfWorks;
using PRM.Services.Generic;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PRM.Services.Services.Example
{
    public interface IPermissionTypeService : IEntityCRUDService<PermissionType, PermissionTypeDto>
    {
    }

    public class PermissionTypeService : EntityCRUDService<PermissionType, PermissionTypeDto>, IPermissionTypeService
    {
        public PermissionTypeService(IMapper mapper, IUnitOfWork<IPRMDbContext> uow, IValidator<PermissionTypeDto> validator) : base(mapper, uow, validator)
        {

        }
    }
}
