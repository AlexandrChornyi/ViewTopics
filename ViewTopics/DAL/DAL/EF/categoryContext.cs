using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;

namespace DAL.EF
{
    public class categoryContext
        : DbContext
    {
        public DbSet<topic> Topics{ get; set; }
        public DbSet<users> Users { get; set; }
        public DbSet<category> Categories { get; set; }
        public DbSet<category_topic> CategoryTopics { get; set; }
        public categoryContext(DbContextOptions options)
            : base(options) { }
    }
}
