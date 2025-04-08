using PRM.Core.BaseModel.BaseEntityDto;
using System;
using System.Collections.Generic;
using System.Text;

namespace PRM.Bl.Dto
{
    public class PermissionDto : BaseEntityDto
    {
        public string EmployeeFirstName { get; set; }
        public string EmployeeLastName { get; set; }
        public DateTime? PermissionDate { get; set; }
        public int? PermissionTypeId { get; set; }
        public string PermissionTypeDescription { get; set; }
    }
}
