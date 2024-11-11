using Healthcare.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Healthcare.DataAccess.Data
{
    public class HealthcareDbContext : DbContext
    {
        public DbSet<Patient>? Patients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(HealthcareDbContext).Assembly);
        }
    }
}