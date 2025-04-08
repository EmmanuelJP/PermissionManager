using System;
using System.Collections.Generic;
using System.Text;

namespace PRM.Core.BaseModel.BaseEntityDto
{
    public interface IBaseEntityDto
    {
        int? Id { get; set; }
        bool Deleted { get; set; }
        DateTimeOffset? CreatedDate { get; set; }
        DateTimeOffset? UpdatedDate { get; set; }
    }
}
