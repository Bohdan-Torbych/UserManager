using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using UserManager.Core.Dtos.Requests;
using UserManager.Core.Dtos.Responses;
using UserManager.Core.Entities;
using UserManager.Core.Enumerations;
using UserManager.Core.Extensions;

namespace UserManager.Core.Mapper;

internal class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<AppUser, UserResponse>()
            .ForMember(userResponse => userResponse.Age, options => 
                options.MapFrom(appUser => appUser.Dob.GetAge()))
            .ForMember(userResponse => userResponse.Gender, options =>
                options.MapFrom(appUser => appUser.Gender.ToString()));
        CreateMap<UserAddRequest, AppUser>()
            .ForMember(appUser => appUser.UserName, options =>
                options.MapFrom(addUser => addUser.Email))
            .ForMember(appUser => appUser.Email, options =>
                options.MapFrom(addUser => addUser.Email))
            .ForMember(appUser => appUser.Gender, options => 
                    options.MapFrom(userAdd => Enum.Parse(typeof(Gender), userAdd.Gender!)));
        CreateMap<LoginAddRequest, Login>();
        CreateMap<Login, LoginResponse>()
            .ForMember(loginResponse => loginResponse.Status, options =>
                options.MapFrom(login => login.Status.ToString()));
    }
}