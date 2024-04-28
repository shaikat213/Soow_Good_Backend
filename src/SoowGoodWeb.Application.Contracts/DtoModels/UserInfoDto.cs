using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace SoowGoodWeb.DtoModels
{
    public class UserInfoDto:FullAuditedEntityDto<Guid>
    {
        public Guid? TenantId { get; set; }

        public string? UserName { get; set; }

        public string? Name { get; set; }

        public string? Surname { get; set; }

        public string? Email { get; set; }

        public bool? EmailConfirmed { get; set; }

        public string? PhoneNumber { get; set; }

        public bool? PhoneNumberConfirmed { get; set; }

        public bool? IsActive { get; set; }

        public bool? LockoutEnabled { get; set; }

        public DateTimeOffset? LockoutEnd { get; set; }

        public string? ConcurrencyStamp { get; set; }
    }

    public class UserSignUpResultDto
    {
        public Guid? UserId { get; set; }
        public string? UserName { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public bool? IsActive { get; set; }
        public bool? Success { get; set; }
        public List<string> Message { get; set; }
    }

    public class UserSignUpCustomDto
    {
        public Guid? UserId { get; set; }
        public string? UserName { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public bool? IsActive { get; set; }
        public bool? Success { get; set; }
        public List<string> Message { get; set; }
    }

    //public class ErroMessageDto
    //{
    //    public Guid? Id { get; set;}
    //    public string? Massage { get; set; }
    //}

    //public class UserRegInfoDto
    //{
    //    public string UserName { get; set; }
    //    public string Name { get; set; }
    //    public string Surname { get; set; }
    //    public string Email { get; set; }
    //    public string PhoneNumber { get; set; }
    //    public bool IsActive { get; set; }
    //    public bool lockoutEnabled { get; set; }
    //    public IList<string> RoleNames { get; set; }
    //    public string Password { get; set; }
    //}
    public class ResetPasswordInputDto
    {
        public string UserId { get; set; }
        public string NewPassword { get; set; }
    }

    public class ResetPasswordResponseDto
    {
        public string? UserName { get; set; }
        public string? Name { get; set; }        
        public bool? Success { get; set; }
        public string? Message { get;set; }
    }
    public class UserRegInfoDto
    {
        public string? UserName { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public bool? IsActive { get; set; }
        public bool? lockoutEnabled { get; set; }
        public IList<string>? RoleNames { get; set; }
        public string? Password { get; set; }
    }

    public class AccountDeteleResponsesDto
    {
        public string? UserName { get; set; }
        public string? Name { get; set; }
        public bool? Success { get; set; }
        public string? Message { get; set; }
    }

    public class JAccessToken
    {
        public string? JwtToken { get; set; }
    }

    public class PatientDetailsForServiceDto
    {
        public string? UserNmae { get; set; }
        public string? Role { get; set; }
        public long? PatientProfileId { get; set; }
        public string? PatientName { get; set; }
        public string? PatientCode { get; set; }
        public bool? Success { get; set; }
        public string? Message { get; set; }
    }

}
