﻿using Aplication.Services.RoleServices;
using AutoMapper;
using Domen.AutoGenerated;
using Domen.EmtityDTO.EmployeeDto;
using Domen.EmtityDTO.ProjectDto;
using Domen.EmtityDTO.RoleDto;
using Infrastructure;
using Infrastructure.Repositories;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;

namespace Aplication.Servises
{
    public class RoleService : IRoleService
    {
        private readonly ConpanyDbContext _conpanyDbContext;
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;

        public RoleService(IRoleRepository roleRepository, IMapper mapper, ConpanyDbContext conpanyDbContext)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
            _conpanyDbContext = conpanyDbContext;
        }

        public async Task<RoleGetDto> CreateRoleAsync(RoleCreateDto roleCreateDto)
        {
            var role = _mapper.Map<Role>(roleCreateDto);
            var roleEntity = await _roleRepository.CreateAsync(role);
            return _mapper.Map<RoleGetDto>(roleEntity);
        }

        public async Task<bool> DeleteRoleAsync(int Id)
        {
            Role? entity = await _conpanyDbContext.Roles.FindAsync(Id);
            if (entity == null)
                return false;

            _conpanyDbContext.Remove(entity);
            await _conpanyDbContext.SaveChangesAsync();
            return true ;
        }

        public async Task<List<RoleGetDto>> GetAllRoleAsync()
        {
         var role =   await _roleRepository.GetAllAsync();
            return _mapper.Map < List<RoleGetDto> >(role);
        }

        public async Task<RoleGetDto> GetByIdRoleAsync(int Id)
        {
           var role = await _roleRepository.GetByIdAsync(Id);
            return role != null ? _mapper.Map<RoleGetDto>(role) : null;
        }

        public async Task<RoleGetDto> UpdateRoleAsync(RoleUpdateDto roleUpdate)
        {
            var role = _mapper.Map<Role>(roleUpdate);
            await _roleRepository.UpdateAsync(role);
            return _mapper.Map<RoleGetDto>(role);
        }

        public async Task RoleCreateExcelFileAsync(List<RoleGetDto> persons)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Sheet1");

                // Sarlavhalarni yozish
                worksheet.Cells[1, 1].Value = "ID";
                worksheet.Cells[1, 2].Value = "Full Name";
                worksheet.Cells[1, 3].Value = "Description";
                worksheet.Cells[1, 4].Value = "Is Active";

                // Ma'lumotlarni yozish
                for (int i = 0; i < persons.Count; i++)
                {
                    worksheet.Cells[i + 2, 1].Value = persons[i].Id;
                    worksheet.Cells[i + 2, 2].Value = persons[i].FullName;
                    worksheet.Cells[i + 2, 3].Value = persons[i].Description;
                    worksheet.Cells[i + 2, 4].Value = persons[i].IsActive;
                }

                // Excel faylini saqlash
                var fileInfo = new FileInfo("D:\\hp.xlsx");
                await package.SaveAsAsync(fileInfo);
            }
        }
    }
}
