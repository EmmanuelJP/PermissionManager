using System;
using System.Collections.Generic;
using System.Text;

namespace PRM.Core.BaseModel.BaseEntity
{
    public class BaseEntity : IBaseEntity
    {
        public virtual int Id { get; set; }
        public virtual bool Deleted { get; set; }
        public virtual DateTimeOffset? CreatedDate { get; set; }
        public virtual DateTimeOffset? UpdatedDate { get; set; }
    }
}
