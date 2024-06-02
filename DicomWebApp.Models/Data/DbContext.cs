using DicomWebApp.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace DicomWebApp.Models.Data
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
    }
}
