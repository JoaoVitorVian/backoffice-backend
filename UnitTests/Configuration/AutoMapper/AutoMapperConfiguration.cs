using Application.ViewModels;
using AutoMapper;
using BackOffice.ViewModels.User;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.AutoMapper
{
    public static class AutoMapperConfiguration
    {
        public static IMapper GetConfiguration()
        {
            var autoMapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserViewModel>()
                    .ReverseMap();

                cfg.CreateMap<CreateUserViewModel, UserViewModel>()
                    .ReverseMap();

                cfg.CreateMap<UpdateUserViewModel, UserUpdateViewModel>()
                    .ReverseMap();
            });

            return autoMapperConfig.CreateMapper();
        }
    }
}
