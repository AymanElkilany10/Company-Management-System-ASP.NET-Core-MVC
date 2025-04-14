﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC_Project.DataAccess.Models.EmployeeMode;
using MVC_Project.DataAccess.Models.Shared.Enums;

namespace MVC_Project.BusinessLayer.DataTransferObjects.EmployeeDtos
{
    public class CreatedEmployeeDto
    {
        [Required(ErrorMessage = "Name Can't be Null")]
        [MaxLength(50, ErrorMessage = "Max length should be 50 character")]
        [MinLength(5, ErrorMessage = "Min length should be 5 characters")]
        public string Name { get; set; } = null!;

        [Range(minimum: 22, maximum: 30)]
        public int? Age { get; set; }

        [RegularExpression(pattern: @"^[1-9][1,3]-[a-zA-Z][5,10]-[a-zA-Z][5,10]-[a-zA-Z][5,10]$",
            ErrorMessage = "Address must be like 123-Street-City-Country")]
        public string? Address { get; set; }

        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }

        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        [Display(Name = "Phone Number")]
        [Phone]
        public string? PhoneNumber { get; set; }

        [Display(Name = "Hiring Date")]
        public DateOnly HiringDate { get; set; }

        public Gender Gender { get; set; }

        public EmployeeType EmployeeType { get; set; }
    }
}
