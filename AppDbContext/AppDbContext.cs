using DataAccess.Entities;
using DataAccess.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class AppDbContext:DbContext
    {

        public AppDbContext(DbContextOptions options):base(options)
        {
            
        }

     public   DbSet<User> Users { get; set; }
     public   DbSet<Product> Products{ get; set; }

    }
}
