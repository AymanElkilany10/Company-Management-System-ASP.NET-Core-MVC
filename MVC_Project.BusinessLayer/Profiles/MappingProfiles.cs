using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MVC_Project.BusinessLayer.DataTransferObjects.EmployeeDtos;
using MVC_Project.DataAccess.Models.DepartmentModel;
using MVC_Project.DataAccess.Models.EmployeeMode;

namespace MVC_Project.BusinessLayer.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() {
            CreateMap<Employee, EmployeeDto>()
                .ForMember(dist => dist.EmpGender, options => options.MapFrom(src => src.Gender))
                .ForMember(dist => dist.EmpType, options => options.MapFrom(src => src.EmployeeType))
                .ForMember(dist => dist.Department, options => options.MapFrom(src => src.Department != null ? src.Department.Name : null));

            CreateMap<Employee, EmployeeDetailsDto>()
                .ForMember(dist => dist.Gender, options => options.MapFrom(src => src.Gender))
                .ForMember(dist => dist.EmployeeType, options => options.MapFrom(src => src.EmployeeType))
                .ForMember(dist => dist.HiringDate, options => options.MapFrom(src => DateOnly.FromDateTime(src.HiringDate)))
                .ForMember(dist => dist.Department, options => options.MapFrom(src => src.Department != null ? src.Department.Name : null));

            CreateMap<CreatedEmployeeDto, Employee>()
                .ForMember(dist => dist.HiringDate, options => options.MapFrom(src => src.HiringDate.ToDateTime(TimeOnly.MinValue)));

            CreateMap<UpdatedEmployeeDto, Employee>()
                .ForMember(dist => dist.HiringDate, options => options.MapFrom(src => src.HiringDate.ToDateTime(TimeOnly.MinValue)));

        }
    }
}
