using System;
using System.Collections.Generic;
using System.Text;

namespace SoowGoodWeb.DtoModels
{
    public class LoginDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string password { get; set; }
        public bool RememberMe { get; set; }
    }

    public class LoginResponseDto
    {
        public Guid? UserId { get; set; }
        public string? UserName { get; set; }
        public List<string> RoleName { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
    public class DeleteUserDataDto
    {
        public string? UserName { get; set; }
    }
}
