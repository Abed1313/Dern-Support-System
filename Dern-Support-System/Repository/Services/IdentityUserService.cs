using Dern_Support_System.Data;
using Dern_Support_System.Models;
using Dern_Support_System.Models.DTO;
using Dern_Support_System.Models.DTO.Response;
using Dern_Support_System.Repository.interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Security.Claims;
using Tunify_Platform.Repositories.Servises;

namespace Dern_Support_System.Repository.Services
{
    public class IdentityUserService : IUser
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly DernSupportDbContext _context;  // Add your DbContext here
        private JwtTokenServeses JwtTokenServeses;

        public IdentityUserService(UserManager<AppUser> userManager,
                                   SignInManager<AppUser> signInManager,
                                   JwtTokenServeses jwtTokenServeses,
                                   DernSupportDbContext context)  // Inject your DbContext
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
            JwtTokenServeses = jwtTokenServeses ?? throw new ArgumentNullException(nameof(jwtTokenServeses));
            _context = context ?? throw new ArgumentNullException(nameof(context));  // Initialize your DbContext
        }

        // Register
        public async Task<RegisterResponse> Register(RegisterUserDTO registerUserDTO, ModelStateDictionary modelState)
        {
            if (!registerUserDTO.Roles.Contains("BusinessCustomer") && !registerUserDTO.Roles.Contains("IndividualCustomer") && !registerUserDTO.Roles.Contains("Admin"))
            {
                throw new ArgumentException("User must have either the 'BusinessCustomer' or 'IndividualCustomer' role to register.");
            }
            // Register the user
            var user = new AppUser
            {
                UserName = registerUserDTO.UserName,
                Email = registerUserDTO.Email,
            };
            var result = await _userManager.CreateAsync(user, registerUserDTO.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRolesAsync(user, registerUserDTO.Roles);
                foreach (var role in registerUserDTO.Roles)
                {
                    switch (role)
                    {
                        case "Admin":
                            var customer = new Customer
                            {
                                Name = registerUserDTO.UserName,
                                Email = registerUserDTO.Email,
                                PhoneNumber = registerUserDTO.PhoneNumber,
                                Address = registerUserDTO.Address,
                                CustomerType = "Admin",
                                AppUserId = user.Id,

                            };
                            break;
                        case "IndividualCustomer":
                            customer = new Customer
                            {
                                Name = registerUserDTO.UserName,
                                Email = registerUserDTO.Email,
                                PhoneNumber = registerUserDTO.PhoneNumber,
                                Address = registerUserDTO.Address,
                                CustomerType = "IndividualCustomer",
                                AppUserId = user.Id
                            };
                            break;
                        case "BusinessCustomer":
                            customer = new Customer
                            {
                                Name = registerUserDTO.UserName,
                                Email = registerUserDTO.Email,
                                PhoneNumber = registerUserDTO.PhoneNumber,
                                Address = registerUserDTO.Address,
                                CustomerType = "BusinessCustomer",
                                AppUserId = user.Id
                            };
                            break;
                    }
                }
                await _context.SaveChangesAsync();

                return new RegisterResponse
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Token = await JwtTokenServeses.GenerateToken(user, TimeSpan.FromMinutes(7)),
                    Roles = await _userManager.GetRolesAsync(user)
                };
            }
            throw new Exception("User creation failed: " + string.Join(", ", result.Errors.Select(e => e.Description)));
        }


        // Login
        public async Task<UserDto> LoginUser(string Username, string Password)
            {
                var user = await _userManager.FindByNameAsync(Username);
            if (user == null || !(await _userManager.CheckPasswordAsync(user, Password)))
            {
                return null; // or return a custom error indicating invalid credentials
            }

            // Generate the token and roles
            var token = await JwtTokenServeses.GenerateToken(user, TimeSpan.FromDays(14));
            var roles = await _userManager.GetRolesAsync(user);

            return new UserDto
            {
                Id = user.Id,
                UserName = user.UserName,
                Token = await JwtTokenServeses.GenerateToken(user, TimeSpan.FromDays(14)),
                Roles = await _userManager.GetRolesAsync(user)
            };
            }
        //public async Task<UserDto> LoginUser(string Username, string Password)
        //{
        //    var user = await _userManager.FindByNameAsync(Username);
        //    if (user == null)
        //    {
        //        return null; // or return a custom error indicating user not found
        //    }

        //    bool passValidation = await _userManager.CheckPasswordAsync(user, Password);
        //    if (passValidation)
        //    {
        //        return new UserDto()
        //        {
        //            Id = user.Id,
        //            UserName = user.UserName,
        //            Token = await JwtTokenServeses.GenerateToken(user, TimeSpan.FromDays(14))
        //        };
        //    }
        //    return null;
        //}
        // Logout
        public async Task<UserDto> LogoutUser(string Username)
            {
                var user = await _userManager.FindByNameAsync(Username);
                if (user == null)
                {
                    return null;
                }

                await _signInManager.SignOutAsync();
                var result = new UserDto()
                {
                    Id = user.Id,
                    UserName = user.UserName
                };
                return result;
            }

            public async Task<UserDto> userProfile(ClaimsPrincipal claimsPrincipal)
            {
                var user = await _userManager.GetUserAsync(claimsPrincipal);

                return new UserDto()
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Token = await JwtTokenServeses.GenerateToken(user, System.TimeSpan.FromDays(14))
                };


            }
            // Delete User
            public async Task<LogDTo> DeleteAccount(string username)
            {
                var account = await _userManager.FindByNameAsync(username);
                if (account == null)
                {
                    throw new Exception("Account not found.");
                }

                await _userManager.DeleteAsync(account);
                return new LogDTo
                {
                    Id = account.Id,
                    UserName = account.UserName
                };
            }
        }
    } 


