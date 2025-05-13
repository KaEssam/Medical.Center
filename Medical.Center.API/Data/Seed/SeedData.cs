using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Medical.Center.API.Models;

namespace Medical.Center.API.Data.Seed;

public static class SeedData
{
    public static async Task SeedRolesAndAdminAsync(IServiceProvider serviceProvider)
    {
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = serviceProvider.GetRequiredService<UserManager<User>>();

        // Seed Roles
        string[] roleNames = { "Owner","Doctor", "Receptionist","Patient" };

        foreach (var roleName in roleNames)
        {
            if (!await roleManager.RoleExistsAsync(roleName))
            {
                await roleManager.CreateAsync(new IdentityRole(roleName));
            }
        }        // Seed Admin User
        var adminUser = await userManager.FindByEmailAsync("Owner@MedicalCenter.com");

        if (adminUser == null)
        {
            var Owner = new User
            {
                UserName = "Owner@MedicalCenter.com",
                Email = "Owner@MedicalCenter.com",
                EmailConfirmed = true,
                FirstName = "System",
                LastName = "Owner",
                Status = "Active"
            };

            var result = await userManager.CreateAsync(Owner, "Owner@123456");

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(Owner, "Owner");
            }
        }
    }
}
