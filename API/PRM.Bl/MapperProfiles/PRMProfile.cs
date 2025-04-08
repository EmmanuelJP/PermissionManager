using AutoMapper;
using PRM.Bl.Dto;
using PRM.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PRM.Bl.MapperProfiles
{
    public class PRMProfile : Profile
    {
        public PRMProfile()
        {
            CreateMap<PermissionType, PermissionTypeDto>();
            CreateMap<PermissionTypeDto, PermissionType>();

            CreateMap<Permission, PermissionDto>()
                .ForMember(y => y.PermissionTypeDescription, x => x.MapFrom(y => y.PermissionType.Description));
            CreateMap<PermissionDto, Permission>();
        }
    }
}
