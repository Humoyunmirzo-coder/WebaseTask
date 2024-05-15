﻿using Domen.AutoGenerated;
using System;
using System.Collections.Generic;
using System.Linq;
using Domen.Model;
using System.Threading.Tasks;
using Nest;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Aplication.Services
{
    public  interface ITokenService
    {
       public string GenerateJwtToken(User user);
    }
}
