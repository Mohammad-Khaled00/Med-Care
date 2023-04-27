using Doctor_Appointment.Models;

namespace Doctor_Appointment.Repo
{
    public interface IDoctorRepo
    {
        public List<Doctor> GetAll();
        public Doctor GetById(int id);
        public void Insert(Doctor doctor, DailyAvailbility daily);
        public void Update(int id, Doctor doctor, DailyAvailbility daily);
        public void Delete(int id);
    }
}
