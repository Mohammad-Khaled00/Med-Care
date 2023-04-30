﻿using Doctor_Appointment.Data;
using Doctor_Appointment.Models;

namespace Doctor_Appointment.Repo.Services
{
    public class DailyAvailbiltyRepoServices : IDailyAvailbilityRepo
    {
        public MedcareDbContext Context { get; }
        public DailyAvailbiltyRepoServices(MedcareDbContext context)
        {
            Context = context;
        }



        public List<DailyAvailbility> GetAll()
        {
            return Context.dailyAvailbilities.ToList();
        }

        public DailyAvailbility GetById(int id)
        {
            return Context.dailyAvailbilities.FirstOrDefault(d => d.Dayid == id);

        }
        public void Insert(DailyAvailbility dailyAvailbility)
        {
            Context.dailyAvailbilities.Add(dailyAvailbility);
            Context.SaveChanges();
        }


        public void Update(int id, DailyAvailbility dailyAvailbility)
        {
            var upd_daily = Context.dailyAvailbilities.FirstOrDefault(d => d.Dayid == id);

            upd_daily.DoctorID = dailyAvailbility.DoctorID;
            upd_daily.date = dailyAvailbility.date;
            upd_daily.starttime = dailyAvailbility.starttime;
            upd_daily.endtime = dailyAvailbility.endtime;
            upd_daily.isavailable = dailyAvailbility.isavailable;

            Context.dailyAvailbilities.Update(upd_daily);
        }
        public void Delete(int id)
        {
            var del = Context.dailyAvailbilities.FirstOrDefault(d => d.Dayid == id);
            Context.dailyAvailbilities.Remove(del);
        }
    }
}