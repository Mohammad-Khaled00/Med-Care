using System.ComponentModel.DataAnnotations;

namespace Doctor_Appointment.Models
{
    public class DoctorViewMode
    {
        public Doctor doctor { get; set; }
        public List<DailyAvailbility> dailyAvailbilities  { get; set; }
   
    }
}
