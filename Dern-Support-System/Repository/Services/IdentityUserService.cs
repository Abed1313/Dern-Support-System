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
        public async Task<RegisterResponse> Register(RegisterUserDTO registerUserDTO)
        {
            // Register the user
            var user = new AppUser
            {
                UserName = registerUserDTO.UserName,
                Email = registerUserDTO.Email,
            };

            var result = await _userManager.CreateAsync(user, registerUserDTO.Password);
            if (!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                return new RegisterResponse
                {
                    Success = false,
                    Message = errors
                };
            }

            // Create a corresponding Customer record based on the role
            if (registerUserDTO.Roles.Contains("Admin"))
            {
                // Create an Admin customer
                var adminCustomer = new Customer
                {
                    Name = registerUserDTO.UserName,
                    Email = registerUserDTO.Email,
                    PhoneNumber = registerUserDTO.PhoneNumber,
                    Address = registerUserDTO.Address,
                    CustomerType = "Admin",
                    AppUserId = user.Id
                };
                _context.Customers.Add(adminCustomer);
            }
            else if (registerUserDTO.Roles.Contains("IndividualCustomer"))
            {
                // Create an Individual customer
                var individualCustomer = new Customer
                {
                    Name = registerUserDTO.UserName,
                    Email = registerUserDTO.Email,
                    PhoneNumber = registerUserDTO.PhoneNumber,
                    Address = registerUserDTO.Address,
                    CustomerType = "IndividualCustomer",
                    AppUserId = user.Id
                };
                _context.Customers.Add(individualCustomer);
            }
            else if (registerUserDTO.Roles.Contains("BusinessCustomer"))
            {
                // Create a Business customer
                var businessCustomer = new Customer
                {
                    Name = registerUserDTO.UserName,
                    Email = registerUserDTO.Email,
                    PhoneNumber = registerUserDTO.PhoneNumber,
                    Address = registerUserDTO.Address,
                    CustomerType = "BusinessCustomer",
                    AppUserId = user.Id
                };
                _context.Customers.Add(businessCustomer);
            }

            // Save changes to the database
            await _context.SaveChangesAsync();

            // Assign the role(s) to the user
            foreach (var role in registerUserDTO.Roles)
            {
                await _userManager.AddToRoleAsync(user, role);
            }

            return new RegisterResponse
            {
                Success = true,
                User = user
            };
        }



        // Login, Logout, DeleteAccount, etc. remain unchanged...



        // Login
        public async Task<UserDto> LoginUser(string Username, string Password)
            {
                var user = await _userManager.FindByNameAsync(Username);
                if (user == null)
                {
                    return null; // or return a custom error indicating user not found
                }

                bool passValidation = await _userManager.CheckPasswordAsync(user, Password);
                if (passValidation)
                {
                    return new UserDto()
                    {
                        Id = user.Id,
                        UserName = user.UserName,
                        Token = await JwtTokenServeses.GenerateToken(user, TimeSpan.FromDays(14))
                    };
                }
                return null;
            }

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

