using ApiDesafioDotnet.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiDesafioDotnet.Data
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {

        }
        public virtual DbSet<importFile> Imports { get; set; }
        public virtual DbSet<User> Auth { get; set; }
        
    }
}
