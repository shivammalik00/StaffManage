using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StaffManage.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StaffManage
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<StaffDetail> StaffDetails { get; set; }
        public DbSet<TaskDetails> TaskDetails { get; set; }
        public DbSet<AssignedTask> AssignedTasks { get; set; }
    }
}
