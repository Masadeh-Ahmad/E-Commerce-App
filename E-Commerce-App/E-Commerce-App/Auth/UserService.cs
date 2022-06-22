using E_Commerce_App.Auth.Interfaces;
using E_Commerce_App.Auth.Models;
using E_Commerce_App.Auth.Models.DTO;
using E_Commerce_App.Data;
using E_Commerce_App.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace E_Commerce_App.Auth
{
    public class UserService : IUserService
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private readonly EcommercelDbContext _context;


        public UserService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> SignInMngr, EcommercelDbContext context)
        {
            _userManager = userManager;
            _signInManager = SignInMngr;
            _context = context; 
        }
        public async Task<UserDto> Register(RegisterDto registerDto, ModelStateDictionary modelstate)
        {

            var user = new ApplicationUser
            {
                UserName = registerDto.UserName,
                Email = registerDto.Email
            };
            Cart cart = new Cart() { userame = user.UserName };
            _context.Add(cart);
            await _context.SaveChangesAsync();
            

            var result = await _userManager.CreateAsync(user, registerDto.Password);
            // Administrator
            // Editor
            

            if (result.Succeeded)
            {
                IList<string> Roles = new List<string>();
                Roles.Add("Administrator");
                await _userManager.AddToRolesAsync(user,Roles);
                return new UserDto
                {
                    Username = user.UserName,
                };
            }

            foreach (var error in result.Errors)
            {
                var errorKey =
                    error.Code.Contains("Password") ? "Password Issue" :
                    error.Code.Contains("Email") ? "Email Issue" :
                    error.Code.Contains("UserName") ? nameof(registerDto.UserName) :
                    "";

                modelstate.AddModelError(errorKey, error.Description);
            }
            return null;

        }


        // Updated 
        public async Task<UserDto> Authenticate(string username, string password)
        {

            var result = await _signInManager.PasswordSignInAsync(username, password, true, false);
            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(username);
            
                
                return new UserDto
                {
                    Id = user.Id,
                    Username = user.UserName,
                    Roles = await _userManager.GetRolesAsync(user)
                };
            }

            return null;

        }
        public async Task<Cart> getCart(string username)
        {

            return  _context.Cart.FirstOrDefault(x => x.userame == username);
        }

        public async Task<UserDto> GetUser(ClaimsPrincipal principal)
        {
            var user = await _userManager.GetUserAsync(principal);
            return new UserDto
            {
                Username = user.UserName
            };
        }
    }
}
