using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _Nuevo.DTO.Objects.AppUserDTOs;
using _Nuevo.DTO.Objects.TagetDTOs;
using _Nuevo.Entities.Concrete;
using _Nuevo.WebUI.Models;

namespace _Nuevo.WebUI.Mapping.Profile
{
    public class MapProfile : AutoMapper.Profile
    {
        public MapProfile()
        {
            #region Target Mapping
            CreateMap<TargetAddDto, Target>();
            CreateMap<Target, TargetAddDto>();
            CreateMap<TargetUpdateDto, Target>();
            CreateMap<Target, TargetUpdateDto>();
            CreateMap<TargetListDto, Target>();
            CreateMap<Target, TargetListDto>();
            CreateMap<TargetForHomePage, Target>();
            CreateMap<Target, TargetForHomePage>();
            #endregion
            #region User Mapping
            CreateMap<AppUserListDto, AppUser>();
            CreateMap<AppUser, AppUserListDto>();
            CreateMap<AppUserAddDto, AppUser>();
            CreateMap<AppUser, AppUserAddDto>();
            CreateMap<AppUserSignInDto, AppUser>();
            CreateMap<AppUser, AppUserSignInDto>();
            #endregion
        }
    }
}
