using Doctor_Appointment.Models;

namespace Doctor_Appointment.Repo.Services
{
    public class DoctorRepoServices : IDoctorRepo
    {
        public MedcareDbContext Context { get; }

        public DoctorRepoServices(MedcareDbContext context)
        {
            Context = context;
        }


        public List<Doctor> GetAll()
        {
            return Context.Doctors.ToList();

        }

        public Doctor GetById(int id)
        {
            return Context.Doctors.FirstOrDefault(d => d.DoctorID == id);
        }

        public void Insert(Doctor doctor, DoctorWorkDays workdays)
        {
            Context.Add(doctor);
            Context.Add(workdays);
            Context.SaveChanges();
        }

        ///////////////////////////////////////////////////////////////////////////////////////////// Alert
        //public void Update(int id, AvailableDays days, Doctor doctor, DoctorWorkDays workdays)
        public void Update(int id, Doctor doctor, DoctorWorkDays workdays)
        {
            var del_Doc = Context.Doctors.FirstOrDefault(p => p.DoctorID == id);
            //var doc_WorkDay = Context.doctorWorkDays.FirstOrDefault(d => d.DoctorID == id && d.WorkDays == days);
            //var doc_WorkDay = Context.doctorWorkDays.FirstOrDefault(d => d.DoctorID == id);

            del_Doc.FullName = doctor.FullName;
            del_Doc.Email = doctor.Email;
            del_Doc.Degree = doctor.Degree;
            del_Doc.Description = doctor.Description;
            del_Doc.Clinic_Location = doctor.Clinic_Location;
            del_Doc.Clinic_PhonNum = doctor.Clinic_PhonNum;
            //doc_WorkDay.WorkDays = workdays.WorkDays;
            del_Doc.HomeExamination = doctor.HomeExamination;

            Context.Doctors.Update(del_Doc);
            Context.SaveChanges();
        }
        public void Delete(int id)
        {
            var del_Doc = Context.Doctors.FirstOrDefault(p => p.DoctorID == id);
            Context.Doctors.Remove(del_Doc);
            Context.SaveChanges();
        }

        public void Insert(Doctor doctor)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, Doctor doctor)
        {
            throw new NotImplementedException();
        }
    }
}
