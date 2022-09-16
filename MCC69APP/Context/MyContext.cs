using MCC69APP.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCC69APP.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> dbContext) : base(dbContext)
        {

        }
        public DbSet<Regions> Regions { get; set; }
        public DbSet<Countries> Countries { get; set; }
        public DbSet<Departments> Departments { get; set; }
        public DbSet<Locations> Locations { get; set; }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<Jobs> Jobs { get; set; }
        public DbSet<JobHistory> JobHistory { get; set; }
    }
}
