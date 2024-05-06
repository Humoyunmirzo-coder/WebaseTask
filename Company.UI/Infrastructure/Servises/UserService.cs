﻿using Aplication.Services;
using AutoMapper;
using Domen.AutoGenerated;
using Domen.EmtityDTO.EmployeeDto;
using Domen.EmtityDTO.UserDto;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Servises
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper  _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }


        public async Task<UserGetDto> CreateUserAynce(UserCreateDto userDto)
        {

            var userentity =  _mapper.Map<User>(userDto);
            userentity.Passwordhash = new PasswordHasher<User>().HashPassword(userentity, userDto.Password);

            var createUser = await _userRepository.CreateAsync(userentity);
            return _mapper.Map<UserGetDto>(createUser);
        }

        public async Task<bool> DeleteUserAynce(int Id)
        {
            return await  _userRepository.DeleteAsync(Id);
        }

        public async Task<List<UserGetDto>> GetAllUserAynce()
        {
            var users = await  _userRepository.GetAllAsync();
            return _mapper.Map<List<UserGetDto>>(users);
        }

        public async Task<UserGetDto> GetByIdUserAynce(int Id)
        {
            var user = await _userRepository.GetByIdAsync(Id);
            return user != null ? _mapper.Map<UserGetDto>(user) : null ;
        }

        public async Task<UserGetDto> UpdateUserAynce(UserUpdateDto userUpdate)
        {
            var user = _mapper.Map<User>(userUpdate);
            await  _userRepository.UpdateAsync(user);
            return _mapper.Map<UserGetDto>(user );
        }
    }
}
