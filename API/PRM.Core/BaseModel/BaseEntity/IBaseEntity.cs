using System;
using System.Collections.Generic;
using System.Text;

namespace PRM.Core.BaseModel.BaseEntity
{
    public interface IBaseEntity
    {
        int Id { get; set; }
        bool Deleted { get; set; }
        DateTimeOffset? CreatedDate { get; set; }
        DateTimeOffset? UpdatedDate { get; set; }
    }
}
