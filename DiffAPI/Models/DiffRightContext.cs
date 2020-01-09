using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DiffApi.Models
{
    public class DiffRightContext : DbContext
    {
        public DiffRightContext(DbContextOptions<DiffRightContext> options)
            : base(options)
        {

        }

        public DbSet<DiffRight> diffRights { get; set; }
    }
}
