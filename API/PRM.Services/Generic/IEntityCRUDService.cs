using PRM.Bl.Models.Interfaces;
using PRM.Core.BaseModel.BaseEntity;
using PRM.Core.BaseModel.BaseEntityDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PRM.Services.Generic
{
    public interface IEntityCRUDService<TEntity, TEntityDto> where TEntity : class, IBaseEntity
       where TEntityDto : class, IBaseEntityDto
    {
        TEntityDto GetById(int id);
        Task<IEntityValidationResult<TEntityDto>> Add(TEntityDto entityDto);
        Task<IEntityValidationResult<TEntityDto>> Update(int id, TEntityDto entityDto);
        Task<TEntityDto> Delete(int id);
        IList<TEntityDto> Get();
    }
}
