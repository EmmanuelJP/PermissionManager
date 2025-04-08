using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PRM.Bl.Models.Interfaces
{

    public interface IBaseController
    {
        Type TypeDto { get; set; }
        IMapper Mapper { get; set; }
        IValidatorFactory ValidationFactory { get; set; }
        UnprocessableEntityObjectResult UnprocessableEntity(object error);
        string TypeName { get; set; }
    }
}
