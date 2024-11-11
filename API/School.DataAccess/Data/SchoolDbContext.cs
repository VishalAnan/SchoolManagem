using Microsoft.EntityFrameworkCore;
using School.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace School.DataAccess.Data
{
   
    public class SchoolDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Mark> Marks { get; set; }

        public SchoolDbContext(DbContextOptions<SchoolDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Add any specific configurations here.
        }
    }

}
