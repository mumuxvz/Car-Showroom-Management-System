using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarModelManagement.infra.Contract;
using CarModelManagement.Core.Contract;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using CarModelManagement.Core.Domain.AuthModel;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace CarModelManagement.Core.Service
{
    public class AuthenticationService : IAuthservice
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public AuthenticationService(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }
        public async Task<string> Register(RegisterModel model)
        {
            try
            {
                var userExists = await _userManager.FindByNameAsync(model.Username);
                if (userExists != null)
                    throw new Exception("User already exists");

                IdentityUser user = new()
                {
                    Email = model.Email,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = model.Username
                };

                var result = await _userManager.CreateAsync(user, model.Password);
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        // Log or inspect the error messages to identify the issue
                        Console.WriteLine($"Error: {error.Code} - {error.Description}");
                    }

                    throw new Exception("User creation failed");
                }
                
                return model.Username;
            }
            catch (Exception ex)
            {
                // Log the exception for further analysis
                Console.WriteLine($"Exception: {ex.Message}");
                throw; // Re-throw the exception for the calling code to handle
            }
        }
        public async Task<string> Login(LoginModel model)
        {
            var user = await _userManager.FindByNameAsync(model.Username);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddHours(3),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );

                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            throw new Exception("User not found");
        }
        public async Task<string> RegisterAdmin(RegisterModel model)
        {
            var userExists = await _userManager.FindByNameAsync(model.Username);
            if (userExists != null)
                throw new Exception("user exist");

            IdentityUser user = new()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                throw new Exception("error in generating admin");

            if (!await _roleManager.RoleExistsAsync(UserRole.CompanyAdmin))
                await _roleManager.CreateAsync(new IdentityRole(UserRole.CompanyAdmin));
            if (!await _roleManager.RoleExistsAsync(UserRole.User))
                await _roleManager.CreateAsync(new IdentityRole(UserRole.User));

            if (await _roleManager.RoleExistsAsync(UserRole.CompanyAdmin))
            {
                await _userManager.AddToRoleAsync(user, UserRole.CompanyAdmin);
            }

            return model.Username;
        }
        public async Task<string> RegisterSuperAdmin(RegisterModel model)
        {
            var userExists = await _userManager.FindByNameAsync(model.Username);
            if (userExists != null)
                throw new Exception("User already exists");

            IdentityUser user = new()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                throw new Exception("Error in generating admin");

            // Check if a Super Admin role already exists
            if (await _roleManager.RoleExistsAsync(UserRole.SuperAdmin))
            {
                // Check if any user is already assigned the Super Admin role
                var superAdminExists = await _userManager.GetUsersInRoleAsync(UserRole.SuperAdmin);
                if (superAdminExists.Any())
                {
                    // If a Super Admin already exists, delete the newly created user
                    await _userManager.DeleteAsync(user);
                    throw new Exception("Super Admin already exists");
                }
            }
            else
            {
                // If the Super Admin role doesn't exist, create it
                await _roleManager.CreateAsync(new IdentityRole(UserRole.SuperAdmin));
            }

            // Create the Super Admin role for the user
            await _userManager.AddToRoleAsync(user, UserRole.SuperAdmin);

            return "Super Admin registered successfully";
        }

    }
}
