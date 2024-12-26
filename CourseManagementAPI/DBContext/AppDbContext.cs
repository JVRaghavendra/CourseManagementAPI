using CourseManagementAPI.Entity;
using CourseManagementAPI.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CourseManagementAPI.DBContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }


        public DbSet<SubscriberCourse> SubscriberCourses { get; set; }

        public DbSet<CourseInfo> CourseInfoSubscriber { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-AM7K2K6;initial Catalog=CourseDB;Integrated Security=True");
        //}
    }

}
