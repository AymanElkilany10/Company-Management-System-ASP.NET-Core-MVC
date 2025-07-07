﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MVC_Project.BusinessLayer.DataTransferObjects.EmployeeDtos;
using MVC_Project.BusinessLayer.Services.Interfaces;
using MVC_Project.DataAccess.Models.EmployeeMode;
using MVC_Project.DataAccess.Models.Shared;
using MVC_Project.DataAccess.Repositories.Interfaces;

namespace MVC_Project.BusinessLayer.Services.Classes
{
    public class EmployeeService(IUnitOfWork _unitOfWork, IMapper _mapper) : IEmployeeService 
    {
        public IEnumerable<EmployeeDto> GetAllEmployees(string? EmployeeSearchName)
        {
            //var employees = _employeeRepository.GetAll(E => E.Name.ToLower().Contains(EmployeeSearchName.ToLower()));

            IEnumerable<Employee> employees;
            if (string.IsNullOrEmpty(EmployeeSearchName))
                employees = _unitOfWork.EmployeeRepository.GetAll();
            else
                employees = _unitOfWork.EmployeeRepository.GetAll(E => E.Name.ToLower().Contains(EmployeeSearchName.ToLower()));

            var employeesDto = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeDto>>(employees);

            return employeesDto;
        }
        public EmployeeDetailsDto? GetEmployeeById(int id)
        {
            var employee = _unitOfWork.EmployeeRepository.GetById(id);

            return employee is null ? null : _mapper.Map<Employee,EmployeeDetailsDto>(employee);
        }
        public int CreateEmployee(CreatedEmployeeDto employeeDto)
        {
            var employee = _mapper.Map<Employee>(employeeDto);
           _unitOfWork.EmployeeRepository.Add(employee);
            return _unitOfWork.SaveChanges();
        }
        
        public int UpdateEmployee(UpdatedEmployeeDto employeeDto)
        {
             _unitOfWork.EmployeeRepository.Update(_mapper.Map<UpdatedEmployeeDto, Employee>(employeeDto));
            return _unitOfWork.SaveChanges();
        }

        public bool DeleteEmployee(int id)
        {
            var employee = _unitOfWork.EmployeeRepository.GetById(id);
            if(employee is null) return false;
            else
            {
                employee.IsDeleted = true;
                _unitOfWork.EmployeeRepository.Update(employee);
                return _unitOfWork.SaveChanges() > 0 ? true : false;
            }
        }

        
    }
}
