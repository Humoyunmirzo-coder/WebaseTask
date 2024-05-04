﻿using Domen.AutoGenerated;
using Domen.EmtityDTO.EmployeeDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Services
{
    public  interface IEmployeeService
    {
        Task<EmployeeGetDto> CreateEmployeeAsync(EmployeeCreateDto employee);
        Task<EmployeeGetDto> UpdateEmployeeAsync(EmployeeUpdateDto employee);
        Task<bool> DeleteEmployeeAsync(int id);
        Task<EmployeeGetDto> GetByIdEmployeeAsync(int id);
        Task<List<EmployeeGetDto>> GetAllEmployeesAsync();

     


    }
}
