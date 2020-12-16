using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using StackUnderflow.DatabaseModel.Models;

namespace StackUnderflow.EF.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
        { 
        } 
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {

        }
        public DbSet<Questions> Questions { get; set; }
    }
}
