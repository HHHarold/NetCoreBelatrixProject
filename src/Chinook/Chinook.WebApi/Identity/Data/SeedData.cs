using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Chinook.WebApi.Identity.Data
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<ApplicationDbContext>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            context.Database.EnsureCreated();

            if (!context.Users.Any())
            {
                var user = new ApplicationUser
                {
                    Email = "hhernandez@belatrixsf.com",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = "hhernandez"
                };

                userManager.CreateAsync(user, "Welcome123!");
            }
        }
    }
}
