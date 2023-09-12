using Application.ViewModels;
using AutoMapper;
using BackOffice.ViewModels.User;
using Domain.Entity;

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

                cfg.CreateMap<User, UserUpdateViewModel>()
                    .ReverseMap();

                cfg.CreateMap<UpdateUserViewModel, UserUpdateViewModel>()
                    .ReverseMap();

                cfg.CreateMap<Departamento, DepartamentoViewModel>()
                    .ReverseMap();

                cfg.CreateMap<UpdateUserViewModel, UserUpdateViewModel>()
                    .ReverseMap();
            });

            return autoMapperConfig.CreateMapper();
        }
    }
}
