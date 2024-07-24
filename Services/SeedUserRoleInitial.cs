using Microsoft.AspNetCore.Identity;

namespace SolomonsAdviceWebApp.Services
{
    public class SeedUserRoleInitial : ISeedUserRoleInitial
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public SeedUserRoleInitial(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task SeedRolesAsync()
        {
            if(!await _roleManager.RoleExistsAsync("Admin"))
            {
                IdentityRole identityRole = new IdentityRole();
                identityRole.Name = "Admin";
                identityRole.NormalizedName = "ADMIN";
                identityRole.ConcurrencyStamp = Guid.NewGuid().ToString();
                IdentityResult identityResult = await _roleManager.CreateAsync(identityRole);
            }

            if (!await _roleManager.RoleExistsAsync("Manager"))
            {
                IdentityRole identityRole = new IdentityRole();
                identityRole.Name = "Manager";
                identityRole.NormalizedName = "Manager";
                identityRole.ConcurrencyStamp = Guid.NewGuid().ToString();
                IdentityResult identityResult = await _roleManager.CreateAsync(identityRole);
            }
        }



        public async Task SeedUsersAsync()
        {
            if (await _userManager.FindByEmailAsync("admin@localhost") == null )
            {
                IdentityUser identityUser = new IdentityUser();
                identityUser.UserName = "admin@localhost";
                identityUser.Email = "admin@localhost";
                identityUser.NormalizedEmail = "ADMIN@LOCALHOST";
                identityUser.NormalizedUserName = "ADMIN@LOCALHOST";
                identityUser.EmailConfirmed = true;
                identityUser.LockoutEnabled = false;
                identityUser.SecurityStamp = Guid.NewGuid().ToString();

                IdentityResult identityResult = await _userManager.CreateAsync(identityUser, "Aa123#");
                if(identityResult.Succeeded)
                {
                    await _userManager.AddToRoleAsync(identityUser, "Admin");
                }
            }

            if (await _userManager.FindByEmailAsync("manager@localhost") == null)
            {
                IdentityUser identityUser = new IdentityUser();
                identityUser.UserName = "manager@localhost";
                identityUser.Email = "manager@localhost";
                identityUser.NormalizedEmail = "MANAGER@LOCALHOST";
                identityUser.NormalizedUserName = "MANAGER@LOCALHOST";
                identityUser.EmailConfirmed = true;
                identityUser.LockoutEnabled = false;
                identityUser.SecurityStamp = Guid.NewGuid().ToString();

                IdentityResult identityResult = await _userManager.CreateAsync(identityUser, "Aa123#");
                if (identityResult.Succeeded)
                {
                    await _userManager.AddToRoleAsync(identityUser, "Manager");
                }
            }
        }
    }
}
