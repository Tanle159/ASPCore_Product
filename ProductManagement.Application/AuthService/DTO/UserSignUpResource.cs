using System;
using System.Collections.Generic;
using System.Text;

namespace ProductManagement.Application.AuthService.DTO
{
    public class UserSignUpResource
    {
        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Password { get; set; }
    }
}
