using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using PRM.Bl.Dto;
using PRM.Model.Entities;
using PRM.Services.Services.Example;
using System.Collections.Generic;

namespace PRM.Api.Controllers
{
    [Route("api/[controller]")]
    public class PermissionTypesController : BaseController<PermissionType, PermissionTypeDto>
    {
        public PermissionTypesController(IPermissionTypeService permissionTypeService, IValidatorFactory validationFactory, IMapper mapper) : base(permissionTypeService, validationFactory, mapper)
        {
        }
    }
}
