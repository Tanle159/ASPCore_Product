using System;
using System.Collections.Generic;
using System.Text;

namespace ProductManagement.Application.AuthService.DTO
{
    public class UserLoginResource
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
