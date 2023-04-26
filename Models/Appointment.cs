using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Doctor_Appointment.Models
{
    public enum AppointmentType
    {
        ClinicalExaminiation,
        HomeExamination
    }

    //[PrimaryKey(nameof(DoctorID), nameof(PatientID))]
    public class Appointment
    {
        //[Key, Column(Order = 0)]
        [ForeignKey("Doctor")]
        public int DoctorID { get; set; }
        public Doctor? doctor { get; set; }

        //[Key, Column(Order = 1)]
        [ForeignKey("Patient")]
        public int PatientID { get; set; }
        public Patient? patient { get; set; }

        [Key]
        public int appointmentID { get; set; }
        public ICollection<DailyAvailbility> availableDays { get; set; } = new HashSet<DailyAvailbility>();

/*        public IEnumerable<DoctorWorkHours> Hours { get; set; }
        public List<int> WorkHours { get; set; }
        public IEnumerable<DoctorWorkDays> Days { get; set; }
        public AvailableDays WorkDays { get; set; }*/

        [EnumDataType(typeof(AppointmentType))]
        public AppointmentType AppointmentType { get; set; }

        public string MedicalHistory { get; set; }


        }

    }

