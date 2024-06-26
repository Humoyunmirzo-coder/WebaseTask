﻿using AutoMapper;
using Domen.AutoGenerated;
using Domen.EmtityDTO.EmployeeDto;
using Domen.EmtityDTO.OrganizationDto;
using Domen.EmtityDTO.ProjectDto;
using Domen.EmtityDTO.TaskDto;
using Domen.EmtityDTO.UserDto;
using Task = Domen.AutoGenerated.Task;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domen.EmtityDTO.RoleDto;
using Domen.EmtityDTO.Token;
using Domen.Model;

namespace Aplication.Mapping
{
    public  class MappingProfile : Profile
    {
 
        public MappingProfile()
        {
            CreateMap<EmployeeCreateDto, Employee>()
                .ForMember(dest => dest.Hiredate, opt => opt.MapFrom(src => DateOnly.FromDateTime(DateTime.Now)));
            CreateMap<Employee, EmployeeGetDto>();
            CreateMap<EmployeeUpdateDto, Employee>();

            CreateMap<OrganizationCreateDto, Organization>();
            CreateMap<Organization, OrganizationGetDto>();
            CreateMap<OrganizationUpdateDto, Organization>();

            CreateMap<TokenDto, Token>();
            CreateMap<Token, TokenDto>();

            CreateMap<RoleCreateDto, Role>();
            CreateMap<Role, RoleGetDto>();
            CreateMap<RoleUpdateDto, Role >();

            CreateMap<TaskCreateDto, Task>()
                .ForMember(des => des.Starttime, opt => opt.MapFrom(src => DateTime.Now))  ;
            CreateMap<Task, TaskGetDto>();
            CreateMap<TaskUpdateDto, Task>();



            CreateMap<ProjectCreateDto, Project>()
                .ForMember(des => des.Appointedday, opt => opt.MapFrom(src => DateTime.UtcNow));
            CreateMap<Project, ProjectGetDto>();
            CreateMap< ProjectUpdateDto, Project>();

            
       
            CreateMap<UserCreateDto, User>().ForMember(s => s.Createdat, s => s.MapFrom( s => DateTime.Now));
            CreateMap<UserCreateDto, User>().ForMember(s => s.Lastlogin, s => s.MapFrom( s => DateTime.Now));
            CreateMap<User, UserGetDto>();
            CreateMap<UserUpdateDto, User>();
        }
    }

}
