﻿using E_Commerce_App.Auth.Models;
using E_Commerce_App.Auth.Models.DTO;
using E_Commerce_App.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Security.Claims;
using System.Threading.Tasks;

namespace E_Commerce_App.Auth.Interfaces
{
    public interface IUserService
    {
        public Task<UserDto> Register(RegisterDto registerDto, ModelStateDictionary modelstate);
        public Task<UserDto> Authenticate(string username, string password);
        public Task<UserDto> GetUser(ClaimsPrincipal principal);
        public Task<string> GetEmail(ClaimsPrincipal principal);
        public Task Logout();


    }
}
