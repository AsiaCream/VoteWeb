using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace VoteWeb.Models
{
    public class VoteWebDBContext:IdentityDbContext<User,IdentityRole<long>,long>
    {
        public VoteWebDBContext(DbContextOptions option) : base(option) { }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Pictrue> Pictrues { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
