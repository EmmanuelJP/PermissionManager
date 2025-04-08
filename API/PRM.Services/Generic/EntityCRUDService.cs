using AutoMapper;
using FluentValidation;
using PRM.Bl.Models;
using PRM.Bl.Models.Interfaces;
using PRM.Core.BaseModel.BaseEntity;
using PRM.Core.BaseModel.BaseEntityDto;
using PRM.Model.Contexts.PRM;
using PRM.Model.Repositories;
using PRM.Model.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRM.Services.Generic
{
    public class EntityCRUDService<TEntity, TEntityDto> : IEntityCRUDService<TEntity, TEntityDto> where TEntity : class, IBaseEntity
      where TEntityDto : class, IBaseEntityDto
    {
        protected readonly IMapper _mapper;
        protected readonly IUnitOfWork<IPRMDbContext> _uow;
        protected readonly IBaseRepository<TEntity> _repository;
        protected readonly IValidator<TEntityDto> _validator;


        public EntityCRUDService(IMapper mapper, IUnitOfWork<IPRMDbContext> uow, IValidator<TEntityDto> validator)
        {
            _mapper = mapper;
            _uow = uow;
            _repository = _uow.GetRepository<TEntity>();
            _validator = validator;
        }

        public virtual IList<TEntityDto> Get()
        {
            IQueryable<TEntity> list = _repository.GetAll();
            IList<TEntityDto> listDto = _mapper.Map<IList<TEntityDto>>(list);
            return listDto;
        }
        public virtual TEntityDto GetById(int id)
        {
            TEntity entity = _repository.GetById(id);

            if (entity is null)
                return null;

            TEntityDto dto = _mapper.Map<TEntityDto>(entity);

            return dto;
        }
        public virtual async Task<IEntityValidationResult<TEntityDto>> Add(TEntityDto entityDto)
        {
            if (_validator.CanValidateInstancesOfType(typeof(TEntityDto)))
            {
                var operation = _validator.Validate(entityDto);
                if (!operation.IsValid)
                    return new EntityValidationResult<TEntityDto>(false, operation.Errors.Select(e => new ValidationFailedModel(e)));
            }

            TEntity entity = _mapper.Map<TEntity>(entityDto);

            _repository.Add(entity);
            await _uow.Commit();

            entityDto = _mapper.Map<TEntityDto>(entity);

            return new EntityValidationResult<TEntityDto>(true, entityDto);
        }
        public virtual async Task<IEntityValidationResult<TEntityDto>> Update(int id, TEntityDto entityDto)
        {
            TEntity entity = _repository.GetById(id);

            if (entity is null)
                return null;

            if (_validator.CanValidateInstancesOfType(typeof(TEntityDto)))
            {
                var operation = _validator.Validate(entityDto);
                if (operation.IsValid is false)
                    return new EntityValidationResult<TEntityDto>(false, operation.Errors.Select(e => new ValidationFailedModel(e)));
            }

            _mapper.Map(entityDto, entity);

            _repository.Update(entity);

            await _uow.Commit();

            entityDto = _mapper.Map(entity, entityDto);

            return new EntityValidationResult<TEntityDto>(true, entityDto);
        }
        public virtual async Task<TEntityDto> Delete(int id)
        {
            TEntity entity = _repository.GetById(id);

            if (entity is null)
                return null;

            _repository.Delete(entity);
            await _uow.Commit();

            TEntityDto entityDto = _mapper.Map<TEntityDto>(entity);

            return entityDto;
        }
    }
}
