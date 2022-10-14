using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Web;

namespace MvcBlogApp.Models
{
    public class BlogContext : DbContext
    {


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=BlogMVCDb;Integrated Security=True");
        }


        public DbSet<Category> Categories { get; set; }
        public DbSet<Blog> Blogs { get; set; }


    }
}