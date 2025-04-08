using System;
using System.Collections.Generic;
using System.Text;

namespace PRM.Bl.Models.Interfaces
{
    public class EntityValidationResult<TEntityDto> : IEntityValidationResult<TEntityDto>
    {
        public EntityValidationResult()
        {

        }
        public EntityValidationResult(bool Success, TEntityDto Data)
        {
            this.Success = Success;
            this.Data = Data;
        }
        public EntityValidationResult(bool Success, IEnumerable<ValidationFailedModel> Errors)
        {
            this.Success = Success;
            this.Errors = Errors;
        }
        public bool Success { get; set; }
        public TEntityDto Data { get; set; }
        public IEnumerable<ValidationFailedModel> Errors { get; set; }
    }
}
