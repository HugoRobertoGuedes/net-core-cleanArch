using System;
using CleanArchMvc.Domain.Account;
using Microsoft.AspNetCore.Identity;

namespace CleanArchMvc.Infra.Data.Identity
{
    public class SeedUserRoleInitial : ISeedUserRole
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        
        public SeedUserRoleInitial(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> manager)
        {
            _userManager = userManager;
            _signInManager = manager;
        }
        
        public void SeedUsers()
        {
            // Administrador
            if (_userManager.FindByEmailAsync("admin@localhost.com").Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = "admin@localhost.com";
                user.Email = "admin@localhost.com";
                user.NormalizedEmail = "ADMIN@LOCALHOST.COM";
                user.NormalizedUserName = "ADMIN@LOCALHOST.COM";
                user.EmailConfirmed = true;
                user.LockoutEnabled = false;
                user.SecurityStamp = Guid.NewGuid().ToString();

                IdentityResult result = _userManager.CreateAsync(user, "jfkl230p").Result;

                if (result.Succeeded)
                {
                    _userManager.AddToRoleAsync(user, "Administrador").Wait();
                }
            }
            
            // Usuario local
            if (_userManager.FindByEmailAsync("local@localhost.com").Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = "local@localhost.com";
                user.Email = "local@localhost.com";
                user.NormalizedEmail = "LOCAL@LOCALHOST.COM";
                user.NormalizedUserName = "LOCAL@LOCALHOST.COM";
                user.EmailConfirmed = true;
                user.LockoutEnabled = false;
                user.SecurityStamp = Guid.NewGuid().ToString();

                IdentityResult result = _userManager.CreateAsync(user, "jfkl230p").Result;

                if (result.Succeeded)
                {
                    _userManager.AddToRoleAsync(user, "Local").Wait();
                }
            }
        }

        public void SeedRoles()
        {
            // Local User
            if (!_roleManager.RoleExistsAsync("Local").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Local";
                role.NormalizedName = "LOCAL";
                IdentityResult roleResult = _roleManager.CreateAsync(role).Result;
                
            }
            
            // Administrador User
            if (!_roleManager.RoleExistsAsync("Administrador").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Administrador";
                role.NormalizedName = "ADMINISTRADOR";
                IdentityResult roleResult = _roleManager.CreateAsync(role).Result;
                
            }
        }
    }
}