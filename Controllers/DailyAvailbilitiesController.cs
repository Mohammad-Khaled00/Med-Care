using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Doctor_Appointment.Models;

namespace Doctor_Appointment.Controllers
{
    public class DailyAvailbilitiesController : Controller
    {
        private readonly MedcareDbContext _context;

        public DailyAvailbilitiesController(MedcareDbContext context)
        {
            _context = context;
        }

        // GET: DailyAvailbilities
        public async Task<IActionResult> Index()
        {
              return _context.dailyAvailbilities != null ? 
                          View(await _context.dailyAvailbilities.ToListAsync()) :
                          Problem("Entity set 'MedcareDbContext.dailyAvailbilities'  is null.");
        }

        // GET: DailyAvailbilities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.dailyAvailbilities == null)
            {
                return NotFound();
            }

            var dailyAvailbility = await _context.dailyAvailbilities
                .FirstOrDefaultAsync(m => m.Dayid == id);
            if (dailyAvailbility == null)
            {
                return NotFound();
            }

            return View(dailyAvailbility);
        }

        // GET: DailyAvailbilities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DailyAvailbilities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DoctorID,Dayid,date,starttime,endtime,isavailable")] DailyAvailbility dailyAvailbility)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dailyAvailbility);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dailyAvailbility);
        }

        // GET: DailyAvailbilities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.dailyAvailbilities == null)
            {
                return NotFound();
            }

            var dailyAvailbility = await _context.dailyAvailbilities.FindAsync(id);
            if (dailyAvailbility == null)
            {
                return NotFound();
            }
            return View(dailyAvailbility);
        }

        // POST: DailyAvailbilities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DoctorID,Dayid,date,starttime,endtime,isavailable")] DailyAvailbility dailyAvailbility)
        {
            if (id != dailyAvailbility.Dayid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dailyAvailbility);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DailyAvailbilityExists(dailyAvailbility.Dayid))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(dailyAvailbility);
        }

        // GET: DailyAvailbilities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.dailyAvailbilities == null)
            {
                return NotFound();
            }

            var dailyAvailbility = await _context.dailyAvailbilities
                .FirstOrDefaultAsync(m => m.Dayid == id);
            if (dailyAvailbility == null)
            {
                return NotFound();
            }

            return View(dailyAvailbility);
        }

        // POST: DailyAvailbilities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.dailyAvailbilities == null)
            {
                return Problem("Entity set 'MedcareDbContext.dailyAvailbilities'  is null.");
            }
            var dailyAvailbility = await _context.dailyAvailbilities.FindAsync(id);
            if (dailyAvailbility != null)
            {
                _context.dailyAvailbilities.Remove(dailyAvailbility);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DailyAvailbilityExists(int id)
        {
          return (_context.dailyAvailbilities?.Any(e => e.Dayid == id)).GetValueOrDefault();
        }
    }
}
