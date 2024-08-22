using Microsoft.EntityFrameworkCore;
using StudentAttendanceTrackingApp.Data.Configurations;
using StudentAttendanceTrackingApp.Data.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAttendanceTrackingApp.Data
{
    public class SATDbContext : DbContext
    {
        public SATDbContext()
        {
            // Unable to create a 'DbContext' of type ''. The exception 'Unable to resolve service for type
            // 'Microsoft.EntityFrameworkCore.DbContextOptions' while attempting to activate 'StudentAttendanceTrackingApp.Data.SATDbContext'.'
            // was thrown while attempting to create an instance. For the different patterns supported at design time,
            // see https://go.microsoft.com/fwlink/?linkid=851728

            // connection string i context içinden verdiğimizde DbContextOptions parametresi verdiğimiz constructor ı program
            // çözümleyemiyor. bu hatayı çözmek için boş constructor ekledik. 
        }
        public SATDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Lesson> Lessons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurations();
            modelBuilder.CreateData();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"Host=localhost;Database=postgres;Username=tt;Password=tt2727;Search Path=satapp");
        }

    }
}
