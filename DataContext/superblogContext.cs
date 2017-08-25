using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using EntityFramework.Models;


namespace EntityFramework.DataContext
{
    public partial class SuperBlogContext : DbContext
    {

        public DbSet<Blog> Blogs {get;set;}


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql(@"Host=localhost;Database=superblog;Username=dev;Password=dev");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {}



    }
}
