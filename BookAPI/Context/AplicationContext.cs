using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPI.Models
{
    public class AplicationContext:DbContext
    {
        public AplicationContext(DbContextOptions<AplicationContext> options):base(options)
        {

        }

        public DbSet<Books> book { get; set; }
    }
}
