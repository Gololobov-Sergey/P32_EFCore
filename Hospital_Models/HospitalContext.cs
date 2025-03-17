using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital_Models.Models;

namespace Hospital_Models
{
    public class HospitalContext : DbContext
    {
        public HospitalContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        public HospitalContext(DbContextOptions<HospitalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Doctor> Doctors { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

            => optionsBuilder.UseSqlServer("Data Source=TAURUS\\SQLEXPRESS;" +
                "Initial Catalog=Hospital_Models;" +
                "Integrated Security=True;" +
                //"Connect Timeout=30;" +
                //"Encrypt=False;" +
                "Trust Server Certificate=True;");
                //"Application Intent=ReadWrite;" +
                //"Multi Subnet Failover=False");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Doctor>().HasData(
                new Doctor { Id = 1, Name = "House, Gregory" },
                new Doctor { Id = 2, Name = "Forman, Eric" },
                new Doctor { Id = 3, Name = "Kaddy, Lisa" }
                );

        }
    }
}
