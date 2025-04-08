using AutoMapper;
using FluentValidation;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using PRM.Api.Filters;
using PRM.Bl.Models.Interfaces;
using PRM.Core.BaseModel.BaseEntity;
using PRM.Core.BaseModel.BaseEntityDto;
using PRM.Services.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace PRM.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class BaseController<TEntity, TEntityDto> : ControllerBase, IBaseController
            where TEntity : class, IBaseEntity
            where TEntityDto : class, IBaseEntityDto
    {
        public IMapper Mapper { get; set; }
        public Type TypeDto { get; set; }
        public string TypeName { get; set; }
        public IValidatorFactory ValidationFactory { get; set; }

        protected readonly IEntityCRUDService<TEntity, TEntityDto> _entityCRUDService;

        public BaseController(IEntityCRUDService<TEntity, TEntityDto> entityCRUDService, IValidatorFactory validationFactory, IMapper mapper)
        {
            _entityCRUDService = entityCRUDService;
            ValidationFactory = validationFactory;
            TypeDto = typeof(List<TEntityDto>);
            TypeName = typeof(TEntity).Name;
            Mapper = mapper;
        }

        /// <summary>
        /// Get all by query options.
        /// </summary>
        /// <returns>A list of records.</returns>
        // [Audit(AuditActionType = AuditActionType.READ)]
        [HttpGet]
        [OData]
        [EnableQuery]
        public virtual IActionResult Get()
        {
            var list = _entityCRUDService.Get();
            return Ok(list);
        }

        /// <summary>
        /// Get a specific record by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A specific record.</returns>
        [HttpGet("{id}")]
        public virtual IActionResult GetById(int id)
        {
            TEntityDto dto = _entityCRUDService.GetById(id);

            if (dto is null)
                return NotFound();

            return Ok(dto);
        }
        /// <summary>
        /// Creates a record.
        /// </summary>
        /// <returns>A newly created record.</returns>
        [HttpPost]
        public virtual async Task<IActionResult> Post([FromBody] TEntityDto entityDto)
        {
            var result = await _entityCRUDService.Add(entityDto);
            if (!result.Success)
                return UnprocessableEntity(result.Errors);
            return CreatedAtAction(WebRequestMethods.Http.Get, new { id = result.Data.Id }, result.Data);
        }

        /// <summary>
        /// Updates a record.
        /// </summary>
        /// <returns>No Content.</returns>
        [HttpPut("{id}")]
        public virtual async Task<IActionResult> Put([FromRoute] int id, [FromBody] TEntityDto entityDto)
        {
            if (entityDto.Id != id)
                return BadRequest();

            var result = await _entityCRUDService.Update(id, entityDto);

            if (result is null)
                return NotFound();

            if (!result.Success)
                return UnprocessableEntity(result.Errors);

            return Ok(result.Data);
        }

        /// <summary>
        /// Deletes a specific record by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A deleted record.</returns>
        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> Delete(int id)
        {
            TEntityDto entityDto = await _entityCRUDService.Delete(id);

            if (entityDto is null)
                return NotFound();

            return Ok(entityDto);
        }
    }
}
