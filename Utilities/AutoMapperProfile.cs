using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNetIdentity.Models;
using ASPNetIdentity.Models.Views;
using AutoMapper;

namespace ASPNetIdentity.Utilities
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //        source, destination
            CreateMap<SignUp, User>()
                .ForMember(destination=>destination.PasswordHash, source=>{
                    source.MapFrom(here=>here.Password);
                })
                .ForMember(destination=>destination.UserName, source=>{
                    source.MapFrom(with=>with.Email);
                });
        }
    }
}