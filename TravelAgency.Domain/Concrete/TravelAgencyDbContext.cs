using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TravelAgency.Domain.Entities;

namespace TravelAgency.Domain.Concrete
{
    public class TravelAgencyDbContext : DbContext
    {
        public TravelAgencyDbContext(DbContextOptions<TravelAgencyDbContext> options) : base(options)
        { }

        public DbSet<TravelAgent> TravelAgents{ get; set; }
        public DbSet<Agency> Agencies { get; set; }

        public TravelAgencyDbContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=travelagencydb;Username=postgres;Password=pass");
        }
    }
}
