using AutoMapper;
using DTOService.DTOs.AppUserDTOs;
using DTOService.DTOs.NotificationDTOs;
using DTOService.DTOs.ReportDTOs;
using DTOService.DTOs.UrgencyDTOs;
using DTOService.DTOs.WorkDTOs;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UILayer.Mapping.AutoMapperProfile
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            #region Urgency
            CreateMap<UrgencyAddDto, Urgency>();
            CreateMap<Urgency, UrgencyAddDto>();

            CreateMap<UrgencyUpdateDto, Urgency>();
            CreateMap<Urgency, UrgencyUpdateDto>();

            CreateMap<UrgencyListDto, Urgency>();
            CreateMap<Urgency, UrgencyListDto>();
            #endregion

            #region AppUser
            CreateMap<LoginDto, AppUser>();
            CreateMap<AppUser, LoginDto>();

            CreateMap<RegisterDto, AppUser>();
            CreateMap<AppUser, RegisterDto>();

            CreateMap<AppUserListDto, AppUser>();
            CreateMap<AppUser, AppUserListDto>();
            #endregion

            #region Notofication
            CreateMap<NotificationListDto, Notification>();
            CreateMap<Notification, NotificationListDto>();
            #endregion

            #region Report
            CreateMap<ReportAddDto, Report>();
            CreateMap<Report, ReportAddDto>();
            CreateMap<ReportUpdateDto, Report>();
            CreateMap<Report, ReportUpdateDto>();
            CreateMap<ReportFileDto, Report>();
            CreateMap<Report, ReportFileDto>();
            #endregion

            #region Work
            CreateMap<WorkListAllDto, Work>();
            CreateMap<Work, WorkListAllDto>();
            CreateMap<WorkListDto, Work>();
            CreateMap<Work, WorkListDto>();
            CreateMap<WorkUpdateDto, Work>();
            CreateMap<Work, WorkUpdateDto>();
            CreateMap<WorkAddDto, Work>();
            CreateMap<Work, WorkAddDto>(); 
            #endregion
        }
    }
}
