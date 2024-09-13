using Dern_Support_System.Models.DTO;
using Dern_Support_System.Models.DTO.Response;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Security.Claims;


namespace Dern_Support_System.Repository.interfaces
{
    public interface IUser
    {
        //Add regester
        Task<RegisterResponse> Register(RegisterUserDTO registerUserDTO, ModelStateDictionary modelState);

        // Add Login 
        public Task<UserDto> LoginUser(string Username , string Password);

        public Task<UserDto> LogoutUser(string Username);
        public Task<LogDTo> DeleteAccount(string username);

        // add user profile 
        public Task<UserDto> userProfile(ClaimsPrincipal claimsPrincipal);
    }
}
