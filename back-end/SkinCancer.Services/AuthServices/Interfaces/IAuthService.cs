﻿using SkinCancer.Entities.AuthModels;
using SkinCancer.Entities.Models;
using SkinCancer.Entities.UserDtos;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkinCancer.Services.AuthServices.Interfaces
{
    public interface IAuthService
    {

        public Task<ProcessResult> RegisterAsync(RegisterModel model);

        public Task<ProcessResult> EmailConfirmationAsync(string UserId, string code);

        public Task<ProcessResult> ForgetPassword(string email , string code);

        public Task<ProcessResult> ResetPasswordAsync(string UserId, string code , string newPassword);

        public Task<AuthResult> LogInAsync(LoginModel model);

        //public Task<JwtSecurityToken> CreateJwtToken(ApplicationUser user);
        public Task<JwtSecurityToken> CreateJwtToken(ApplicationUser user);

        public Task<string> AddRoleAsync(RoleModel model); 
    }
}
