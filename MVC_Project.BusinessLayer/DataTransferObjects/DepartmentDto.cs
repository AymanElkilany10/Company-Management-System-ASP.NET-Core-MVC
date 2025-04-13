﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace MVC_Project.BusinessLayer.DataTransferObjects
{
    public class DepartmentDto
    {
        public int DeptId { get; set; }
        public string Name { get; set; }= String.Empty;
        public string Code { get; set; } = String.Empty;
        public string? Description { get; set; }
        public DateOnly? DateOfCreation { get; set; }


    }
}
