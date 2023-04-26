using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace Doctor_Appointment.Models
{

    public enum AvailableDays
    {
        Saturday, Sunday, Monday, Tuesday, Wednesday, Thursday
    }

    [PrimaryKey(nameof(DoctorID), nameof(WorkDays))]
    public class DoctorWorkDays
    {
        [ForeignKey("Doctor")]
        public int DoctorID { get; set; }


        [Required]
        [EnumDataType(typeof(AvailableDays))]
        public AvailableDays WorkDays { get; set; }
        public IEnumerable<Doctor> AvailableDays { get; set; }
    }
}