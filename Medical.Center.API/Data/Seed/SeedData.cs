using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Medical.Center.API.Models;

namespace Medical.Center.API.Data.Seed;

public static class SeedData
{    public static async Task SeedRolesAndAdminAsync(IServiceProvider serviceProvider)
    {
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = serviceProvider.GetRequiredService<UserManager<User>>();
        var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
        var logger = loggerFactory?.CreateLogger("SeedData");

        // Seed Roles
        string[] roleNames = { "Owner", "Doctor", "Receptionist", "Patient" };

        foreach (var roleName in roleNames)
        {
            if (!await roleManager.RoleExistsAsync(roleName))
            {
                var result = await roleManager.CreateAsync(new IdentityRole(roleName));
                if (result.Succeeded)
                {
                    logger?.LogInformation($"Role {roleName} created successfully");
                }
                else
                {
                    logger?.LogWarning($"Failed to create role {roleName}");
                }
            }
        }
          // Seed Admin User
        var adminUser = await userManager.FindByEmailAsync("Owner@MedicalCenter.com");

        if (adminUser == null)
        {
            logger?.LogInformation("Creating default owner user");
            var owner = new User
            {
                UserName = "Owner@MedicalCenter.com",
                Email = "Owner@MedicalCenter.com",
                EmailConfirmed = true,
                FirstName = "System",
                LastName = "Owner",
                Status = "Active"
            };

            var result = await userManager.CreateAsync(owner, "Owner@123456");

            if (result.Succeeded)
            {
                logger?.LogInformation("Default owner created successfully");
                await userManager.AddToRoleAsync(owner, "Owner");
            }
            else
            {
                logger?.LogWarning("Failed to create default owner: {Errors}",
                    string.Join(", ", result.Errors.Select(e => e.Description)));
            }
        }
        else
        {
            logger?.LogInformation("Default owner already exists");
        }
    }
}
