using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ContactListAPI.Models
{
    public class PeopleDbContext: DbContext
    {

        public PeopleDbContext(DbContextOptions<PeopleDbContext> options):base(options)
        {

        }

        public DbSet<People> People { get; set; }
    }
}
