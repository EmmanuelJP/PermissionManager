using System;
using System.Collections.Generic;
using System.Text;

namespace PRM.Bl.Models.Interfaces
{
    public interface IEntityValidationResult<TEntityDto>
    {
        bool Success { get; set; }
        TEntityDto Data { get; set; }
        IEnumerable<ValidationFailedModel> Errors { get; set; }
    }
}
