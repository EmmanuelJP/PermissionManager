using System;
using System.Collections.Generic;
using System.Text;

namespace PRM.Core.BaseModel.BaseEntityDto
{
    public class BaseEntityDto  : IBaseEntityDto
    {
        public int? Id { get; set; }
        public bool Deleted { get; set; }
        public DateTimeOffset? CreatedDate { get; set; }
        public DateTimeOffset? UpdatedDate { get; set; }
    }
}
