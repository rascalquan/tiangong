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
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            //optionsBuilder.UseMySql(configuration["Conn:TGConn"]);
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Hotel> Hotels { get; set; }

    }
}
