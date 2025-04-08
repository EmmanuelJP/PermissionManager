using AutoMapper;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PRM.Bl.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PRM.Api.Filters
{
    public class ODataAttribute : ActionFilterAttribute
    {
        public IMapper _mapper;
        public Type _type;

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            var controller = context.Controller as IBaseController;

            var odataFeature = context.HttpContext.ODataFeature();
            var result = context.Result;
            if (odataFeature != null && result is OkObjectResult objectResult)
            {
                if (odataFeature.TotalCount != null)
                {
                    var dto = controller.Mapper.Map(objectResult.Value, objectResult.Value.GetType(), controller.TypeDto);
                    objectResult.Value = new { count = odataFeature.TotalCount, Data = dto };
                    context.Result = objectResult;
                    context.HttpContext.Response.Headers.Add("$odatacount", odataFeature.TotalCount.ToString());
                }
            }
            base.OnActionExecuted(context);
        }
    }
}
