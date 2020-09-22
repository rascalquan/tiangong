using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TianGong.Models;

namespace TianGong.Repository
{
    public class TGContext:DbContext
    {
        public TGContext(DbContextOptions<TGContext> options)
            :base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hotel>().ToTable("Hotel");
        }
        public DbSet<Hotel> Hotels { get; set; }

    }
}
