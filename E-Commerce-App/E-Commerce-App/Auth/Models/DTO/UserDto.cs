using System.Collections.Generic;

namespace E_Commerce_App.Auth.Models.DTO
{
    public class UserDto
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public IList<string> Roles { get; set; }

    }
}
