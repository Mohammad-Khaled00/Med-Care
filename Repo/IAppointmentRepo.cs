﻿using Doctor_Appointment.Models;

namespace Doctor_Appointment.Repo
{
    public interface IAppointmentRepo
    {
        public List<Appointment> GetAll();
        public Appointment GetById(int DocId , int PatId);
        public void Insert(Appointment appointment);
        public void Update(int id, Appointment appointment);
        public void Delete(int id);
    }
}
