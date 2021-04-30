using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SchoolProject2.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolProject2.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {}

        public DbSet<AdminUser> AdminUsers { get; set; }
        public DbSet<StudentUser> StudentUsers { get; set; }
        public DbSet<TeacherUser> TeacherUsers { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}
