﻿using System.ComponentModel.DataAnnotations;

namespace E_Commerce_App.Auth.Models.DTO
{
    public class LoginDTO
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
