using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using PRM.Bl.Dto;
using PRM.Model.Entities;
using PRM.Services.Services.Example;

namespace PRM.Api.Controllers
{
    [Route("api/[controller]")]
    public class PermissionsController : BaseController<Permission, PermissionDto>
    {
        public PermissionsController(IPermissionService permissionService, IValidatorFactory validationFactory, IMapper mapper) : base(permissionService, validationFactory, mapper)
        {
        }
    }
}
