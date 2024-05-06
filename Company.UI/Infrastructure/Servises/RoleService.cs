using Aplication.Services;
using AutoMapper;
using Domen.EmtityDTO.RoleDto;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Servises
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;

        public RoleService(IRoleRepository roleRepository, IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        public Task<RoleGetDto> CreateRoleAsync(RoleCreateDto role)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteRoleAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<RoleGetDto>> GetAllRoleAsync()
        {
            throw new NotImplementedException();
        }

        public Task<RoleGetDto> GetByIdRoleAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<RoleGetDto> UpdateRoleAsync(RoleUpdateDto role)
        {
            throw new NotImplementedException();
        }
    }
}
