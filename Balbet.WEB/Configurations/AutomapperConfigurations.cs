using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Balbet.BL.Configurations;
using Balbet.WEB.Models;
using Balbet.BL.ModelsDTO;

namespace Balbet.WEB.Configurations
{
    public class AutomapperConfigurations
    {
        public static void RegisterConfigurations()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<AutomapperProfile>();

                cfg.CreateMap<UserDTO, UserViewModel>()
                .ForMember(destinationMember => destinationMember.Passport,
                memberOptions => memberOptions.MapFrom(src => new PassportViewModel(src.Passport)));
                cfg.CreateMap<UserViewModel, UserDTO>()
                .ForMember(destinationMember => destinationMember.Passport,
                memberOptions => memberOptions.MapFrom(src => src.Passport.Seria + src.Passport.Code));
            });
        }
    }
}