using Doctor_Appointment.Models;
using Doctor_Appointment.Repo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Doctor_Appointment.Controllers
{
    public class DoctorsController : Controller
    {
        public MedcareDbContext Context { get; }
        public IDoctorRepo doctor { get; }
        public IDailyAvailbilityRepo AvailbilityRepo { get; }

        public DoctorsController(MedcareDbContext context , IDoctorRepo _doctor)
        {
            Context = context;
            doctor = _doctor;
        }
        // GET: DoctorsController
        public ActionResult Index()
        {
            return View(doctor.GetAll());
        }

        // GET: DoctorsController/Details/5
        public ActionResult Details(int id)
        {
            var check = Context.Doctors.FirstOrDefault(c=>c.DoctorID==id);
            if(check!=null)
            {

                try
                {
                    return View(doctor.GetById(id));
                }
                catch(Exception ex)
                {
                    throw new Exception(ex.Message);
                }

            }
              return NotFound();
        }

        // GET: DoctorsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DoctorsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Doctor doc , DailyAvailbility daily)
        {
            try
            {
                doctor.Insert(doc,daily);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DoctorsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DoctorsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DoctorsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DoctorsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
