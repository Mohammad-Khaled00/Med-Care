using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Doctor_Appointment.Models;
using Doctor_Appointment.Repo;

namespace Doctor_Appointment.Controllers
{
    public class AppointmentsController : Controller
    {
        private readonly MedcareDbContext _context;

        public IAppointmentRepo Repo { get; }

        public AppointmentsController(MedcareDbContext context, IAppointmentRepo repo)
        {
            _context = context;
            Repo = repo;
        }

        // GET: Appointments

        public async Task<IActionResult> Index()
        {
      
                return View(Repo.GetAll());
         
        }
        //public async Task<IActionResult> Index(int PatId)
        //{
        //    var check = _context.Appointments.Where(p => p.PatientID==PatId);
        //    if (check!=null)
        //    {
        //        return View(Repo.GetAll(PatId));
        //    }
        //    else
        //        return NotFound();
        //}

        // GET: Appointments/Details/5
        public IActionResult Details(int PatId)
        {
            if (PatId == null || _context.Appointments == null)
            {
                return NotFound();
            }

            var appointment =  _context.Appointments
                .Include(a => a.doctor)
                .Include(a => a.patient)
                .Where(m => m.PatientID==PatId);
            if (appointment == null)
            {
                return NotFound();
            }

            return View(Repo.GetById(PatId));
        }

        // GET: Appointments/Create
        public IActionResult Create()
        {
            ViewData["DoctorID"] = new SelectList(_context.Doctors, "DoctorID", "FullName");
            ViewData["PatientID"] = new SelectList(_context.Patients, "PatientID", "FullName");
            return View();
        }

        // POST: Appointments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DoctorID,PatientID,AppointmentDay,AppointmentTime,AppointmentType,MedicalHistory")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(appointment);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details");
            }
            ViewData["DoctorID"] = new SelectList(_context.Doctors, "DoctorID", "FullName", appointment.DoctorID);
            ViewData["PatientID"] = new SelectList(_context.Patients, "PatientID", "FullName", appointment.PatientID);
            return View(appointment);
        }

        // GET: Appointments/Edit/5
        public IActionResult Edit(int DocId , int PatId)
        {
            if (DocId == null || PatId ==null || _context.Appointments == null)
            {
                return NotFound();
            }

            var appointment = _context.Appointments.FirstOrDefault(a => a.DoctorID==DocId && a.PatientID==PatId);
            if (appointment == null)
            {
                return NotFound();
            }
            //ViewBag.DoctorID = new SelectList(_context.Doctors, "DoctorID", "FullName", appointment.DoctorID);
            //ViewBag.PatientID= new SelectList(_context.Patients, "PatientID", "FullName", appointment.PatientID);
            return View(appointment);
        }

        // POST: Appointments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("DoctorID,PatientID,AppointmentDay,AppointmentTime,AppointmentType,MedicalHistory")] Appointment appointment)
        {
   

            if (ModelState.IsValid)
            {
                try
                {
                    Repo.Update(appointment.DoctorID,appointment.PatientID,appointment);
                }
                catch (DbUpdateConcurrencyException)
                {
                        return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
           
            return View(appointment);
        }

        // GET: Appointments/Delete/5
        public async Task<IActionResult> Delete(int Docid , int Patid)
        {

            var appointment = await _context.Appointments
                .Include(a => a.doctor)
                .Include(a => a.patient)
                .FirstOrDefaultAsync(m => m.DoctorID == Docid && m.PatientID==Patid);

            if (appointment != null)
            {
                Repo.Delete(appointment.DoctorID,appointment.PatientID);
            }

            return View(appointment);
        }

        // POST: Appointments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int DocId, int PatId)
        {
            //if (_context.Appointments == null)
            //{
            //    return Problem("Entity set 'MedcareDbContext.Appointments'  is null.");
            //}
            var appointment = _context.Appointments.FirstOrDefault(m=>m.DoctorID== DocId && m.PatientID== PatId);
            if (appointment != null)
            {
                Repo.Delete(DocId , PatId);

            }
            return RedirectToAction(nameof(Index));
        }

        private bool AppointmentExists(int id)
        {
          return (_context.Appointments?.Any(e => e.DoctorID == id)).GetValueOrDefault();
        }
    }
}
