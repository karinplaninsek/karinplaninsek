﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DiffApi.Models
{
    public class DiffContext : DbContext
    {
        public DiffContext(DbContextOptions<DiffContext> options)
            : base(options)
        {

        }

        public DbSet<Diff> Diffs { get; set; }
    }
}
