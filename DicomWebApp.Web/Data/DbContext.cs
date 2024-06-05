
using DicomWebApp.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace DicomWebApp.Web.Data
{
    public class MyDicomContext : DbContext
    {
        public MyDicomContext(DbContextOptions<MyDicomContext> options) : base(options) 
        {

        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Study> Studies { get; set; }
        public DbSet<Series> Series { get; set; }
        public DbSet<Image> Images { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Patient>()
                .HasMany(p => p.Studies)
                .WithOne(s => s.Patient)
                .HasForeignKey(s => s.PatientId);

            modelBuilder.Entity<Study>()
                .HasMany(s => s.Series)
                .WithOne(se => se.Study)
                .HasForeignKey(se => se.StudyId);

            modelBuilder.Entity<Series>()
                .HasMany(se => se.Images)
                .WithOne(i => i.Series)
                .HasForeignKey(i => i.SeriesId);
        }
    }
}
