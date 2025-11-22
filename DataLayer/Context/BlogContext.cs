using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Context
{
    public class BlogContext :DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options): base(options)
        {

        }

        public DbSet<Post> Post { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<PostComment> PostComment { get; set; }


        //رفع ارور در روابط جداول یا کلاس ها
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(s => s.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
            base.OnModelCreating(modelBuilder);
        }
    }
}
