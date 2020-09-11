using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tiangong.Models;

namespace tiangong.Repository
{
    public class TGContext:DbContext
    {
        IConfiguration Configuration;
        public TGContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(Configuration["Conn:TGConn"]);
            //base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Hotel> Hotels { get; set; }

    }
}
