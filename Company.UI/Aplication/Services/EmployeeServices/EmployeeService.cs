﻿using Aplication.Services.EmployeeServices;
using AutoMapper;
using Domen.AutoGenerated;
using Domen.EmtityDTO.EmployeeDto;
using Domen.Repositories;
using Infrastructure.GenericRepository;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Services.EmployeeServices
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ConpanyDbContext _conpanyDbContext;
        private readonly IEmployeeRepository _repository;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository repository, IMapper mapper, ConpanyDbContext conpanyDbContext)
        {
            _repository = repository;
            _mapper = mapper;
            _conpanyDbContext = conpanyDbContext;
        }
        public async Task<EmployeeGetDto> CreateEmployeeAsync(EmployeeCreateDto employeeDto)
        {
            var employee = _mapper.Map<Employee>(employeeDto);
            var createdEmployee = await _repository.CreateAsync(employee);
            return _mapper.Map<EmployeeGetDto>(createdEmployee);
        }

        public async Task<bool> DeleteEmployeeAsync(int id)
        {
            Employee? entity = await _conpanyDbContext.Employees.FindAsync(id);
            if (entity == null)
                return false;

            _conpanyDbContext.Remove(entity);
            await _conpanyDbContext.SaveChangesAsync();
            return true;
        }

      

        public async Task<List<EmployeeGetDto>> GetAllEmployeesAsync()
        {
            var employees = await _repository.GetAllAsync();
            return _mapper.Map<List<EmployeeGetDto>>(employees);
        }

        public async Task<EmployeeGetDto> GetByIdEmployeeAsync(int id)
        {
            var employee = await _repository.GetByIdAsync(id);
            return employee != null ? _mapper.Map<EmployeeGetDto>(employee) : null;
        }

        public async Task<EmployeeGetDto> UpdateEmployeeAsync(EmployeeUpdateDto employeeDto)
        {
            var employee = _mapper.Map<Employee>(employeeDto);
            await _repository.UpdateAsync(employee);
            return _mapper.Map<EmployeeGetDto>(employee);
        }
    }
}
