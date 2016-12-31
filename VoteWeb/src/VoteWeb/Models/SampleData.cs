using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace VoteWeb.Models
{
    public static class SampleData
    {
        public async static Task InitDB(IServiceProvider service)
        {
            var DB = service.GetRequiredService<VoteWebDBContext>();

            var userManager = service.GetRequiredService<UserManager<User>>();

            var roleManager = service.GetRequiredService<RoleManager<IdentityRole<long>>>();

            if (DB.Database != null && DB.Database.EnsureCreated())
            {
                await roleManager.CreateAsync(new IdentityRole<long> { Name = "超级管理员" });
                await roleManager.CreateAsync(new IdentityRole<long> { Name = "管理员" });
                await roleManager.CreateAsync(new IdentityRole<long> { Name = "普通用户" });

                var SuperAdmin = new User
                {
                    UserName = "SAdmin",
                    CreateTime = DateTime.Now
                };
                await userManager.CreateAsync(SuperAdmin, "123456");
                await userManager.AddToRoleAsync(SuperAdmin, "超级管理员");

                var Admin = new User
                {
                    UserName = "Admin",
                    CreateTime = DateTime.Now,
                };
                await userManager.CreateAsync(Admin, "123456");
                await userManager.AddToRoleAsync(Admin, "管理员");

                var Guest = new User
                {
                    UserName = "Guest",
                    CreateTime = DateTime.Now,
                };
                await userManager.CreateAsync(Guest, "123456");
                await userManager.AddToRoleAsync(Guest, "普通用户");
            }
            DB.SaveChanges();
        }
    }
}
