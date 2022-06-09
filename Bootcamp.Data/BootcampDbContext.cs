using Bootcamp.Domain.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootcamp.Data
{
    public class BootcampDbContext : DbContext
    {
        public BootcampDbContext(DbContextOptions<BootcampDbContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
    }
}
