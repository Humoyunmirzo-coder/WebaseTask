﻿using Domen.AutoGenerated;
using Domen.EmtityDTO.Token;
using Domen.EmtityDTO.UserDto;
using Domen.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Services
{
    public  interface IIdentityServise
    {
        Task<UserGetDto> RegisterAsync(User user);
        Task< UserGetDto> LoginAsync(UserCreateDto userCreate);
        Task<bool> LogoutAsync();
        Task<TokenDto> RefreshTokenAsync(Token token , int Id);
        Task<bool> SaveRefreshToken(string refreshToken, User user);
        Task<bool> IsValidRefreshToken(string refreshToken, int userId);
    }
}
