using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DiffApi.Models
{
    public class DiffLeftContext : DbContext
    {
        public DiffLeftContext(DbContextOptions<DiffLeftContext> options)
            : base(options)
        {

        }

        public DbSet<DiffLeft> DiffLefts { get; set; }
    }
}
