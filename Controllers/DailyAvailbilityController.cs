using Doctor_Appointment.Data;
using Doctor_Appointment.Models;
using Doctor_Appointment.Repo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Doctor_Appointment.Controllers
{
    public class DailyAvailbilityController : Controller
    {
        public MedcareDbContext Context { get; }
        public IDailyAvailbilityRepo Daily { get; }

        public DailyAvailbilityController(MedcareDbContext context, IDailyAvailbilityRepo daily)
        {
            Context = context;
            Daily = daily;
        }

        // GET: DailyAvailbilityControllr
        public ActionResult Index()
        {
            try
            {
                Daily.GetAll();
                return View();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return View();
        }

        // GET: DailyAvailbilityControllr/Details/5
        public ActionResult Details(int id)
        {

            return View();
        }

        // GET: DailyAvailbilityControllr/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DailyAvailbilityControllr/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: DailyAvailbilityControllr/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DailyAvailbilityControllr/Edit/5
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

        // GET: DailyAvailbilityControllr/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DailyAvailbilityControllr/Delete/5
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
