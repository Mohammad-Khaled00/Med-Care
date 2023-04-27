using Microsoft.EntityFrameworkCore;
using System.Xml;

namespace Doctor_Appointment.Models
{
    public class MedcareDbContext : DbContext
    {
        public MedcareDbContext(DbContextOptions<MedcareDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Appointment>()
                .HasKey(e => new { e.DoctorID, e.PatientID });
        }

        public DbSet<Patient> Patients { get; set; }

        public DbSet<Doctor> Doctors { get; set; }

        public DbSet<Appointment> Appointments { get; set; }

        public DbSet<DailyAvailbility> dailyAvailbilities { get; set; }


    }
}
