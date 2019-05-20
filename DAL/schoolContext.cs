using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using CollegeDBEF.Models;

namespace CollegeDBEF.DAL
{
    public class schoolContext : DbContext
    {
        public schoolContext() : base("schoolContext")
        {

        }
        public DbSet<Classes> Classes { get; set; }
        public DbSet<DepartmentTypes> DepartmentTypes { get; set; }
        public DbSet<Scores> Scores { get; set; }
        public DbSet<ScoreTypes> ScoreTypes { get; set; }
        public DbSet<Students> Students { get; set; }
        public DbSet<StudentClasses> StudentClasses { get; set; }
    }
}