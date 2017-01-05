using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using Microsoft.Extensions.Configuration;

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
                #region 初始化角色信息
                await roleManager.CreateAsync(new IdentityRole<long> { Name = "超级管理员" });
                await roleManager.CreateAsync(new IdentityRole<long> { Name = "管理员" });
                await roleManager.CreateAsync(new IdentityRole<long> { Name = "普通用户" }); 
                #endregion

                #region 初始化管理员和用户
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
                DB.SaveChanges();
                #endregion

                #region 初始化60条分类
                for (var i = 0; i < 60; i++)
                {
                    var category = new Category
                    {
                        Title = i > 30 ? (i % 2 == 0 ? "山水画" + i : "人物画" + i) : (i % 2 == 0 ? "风景画" + i : "素描" + i),
                        PRI = i % 10,
                        UserID = SuperAdmin.UserID,
                        CreateTime = DateTime.Now,
                        StartTime = DateTime.Now,
                        EndTime = DateTime.Now,
                        IsDelete = i % 6 == 0 ? 1 : 0,
                        IsEnd = i % 5 == 0 ? 1 : 0
                    };
                    DB.Categorys.Add(category);
                }
                
                #endregion

                #region 初始化upload文件夹
                var rootFile=".\\wwwroot\\upload";
                if(!Directory.Exists(rootFile)){
                        Directory.CreateDirectory(rootFile);
                    }
                #endregion
                
                #region 初始化20条个作者
                
                for(var i=0;i<20;i++)
                {
                    var author=new Author
                    {
                        Name="作者"+i,
                        Email=i+"@qq.com",
                        CreateTime=DateTime.Now,
                        Introduction="作者"+i+"简介"
                    };
                    DB.Authors.Add(author);
                    DB.SaveChanges();
                    var authorFile=author.AuthorID.ToString()+author.Name;
                    if(!Directory.Exists(rootFile+authorFile)){
                        Directory.CreateDirectory(Directory.CreateDirectory(rootFile+authorFile));
                    }
                }
                #endregion
            }
            DB.SaveChanges();
        }
    }
}
