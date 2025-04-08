using PRM.Core.BaseModel.BaseEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PRM.Model.Entities
{
    public class PermissionType : BaseEntity
    {
        public PermissionType()
        {
            Permissions = new HashSet<Permission>();
        }
        public string Description { get; set; }
        public virtual ICollection<Permission> Permissions { get; set; }
    }
}
