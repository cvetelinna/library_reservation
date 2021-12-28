using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using library_reservation.Data;
using library_reservation.Models;

namespace library_reservation.Controllers
{
    public class ReservationController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReservationController(ApplicationDbContext context)
        {
            _context = context;
        }

        // POST: Reservation/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        public void CreateRecurring(
            [Bind("Id,RecurrenceType,StartDate,EndType,EndCounter,EndDate,RecurrinMonths,RecurringDays")] 
             RecurringSettings recurringSettings)
        {
            _context.Add(recurringSettings);
        }

        // GET: Reservation
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Reservations.Include(r => r.Hall);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Reservation/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservationModel = await _context.Reservations
                .Include(r => r.Hall)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reservationModel == null)
            {
                return NotFound();
            }

            return View(reservationModel);
        }

        // GET: Reservation/Create
        public IActionResult Create()
        {
            ViewData["HallId"] = new SelectList(_context.Halls, "Id", "Name");
            return View();
        }

        //[Bind("Id,RecurrenceType,StartDate,EndType,EndCounter,EndDate,RecurrinMonths,RecurringDays")] RecurringSettings recurringSettings
        // POST: Reservation/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("Id,HallId,UserId,StartDate,EndDate,Subject,Organizers,Description,RequiresMultimedia,RecurringSettingsId,IsRecurring")] ReservationModel reservationModel, 
            [Bind("Id,RecurrenceType,RecurrenceStartDate,EndType,EndCounter,RecurrenceEndDate,RecurrinMonths,RecurringDays")] RecurringSettings recurrenceSettings)
        { 
            if (ModelState.IsValid)
            {
                
                if (reservationModel.IsRecurring)
                {
                    _context.Add(recurrenceSettings);
                    await _context.SaveChangesAsync();
                    reservationModel.RecurringSettingsId = recurrenceSettings.Id;
                }
               
                _context.Add(reservationModel);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            ViewData["HallId"] = new SelectList(_context.Halls, "Id", "Name", reservationModel.HallId);
            return View(reservationModel);
        }

        // GET: Reservation/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservationModel = await _context.Reservations.FindAsync(id);
            if (reservationModel == null)
            {
                return NotFound();
            }
            ViewData["HallId"] = new SelectList(_context.Halls, "Id", "Id", reservationModel.HallId);
            return View(reservationModel);
        }

        // POST: Reservation/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,HallId,UserId,StartDate,EndDate,Subject,Organizers,Description,RequiresMultimedia")] ReservationModel reservationModel)
        {
            if (id != reservationModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reservationModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservationModelExists(reservationModel.Id))
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
            ViewData["HallId"] = new SelectList(_context.Halls, "Id", "Id", reservationModel.HallId);
            return View(reservationModel);
        }

        // GET: Reservation/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservationModel = await _context.Reservations
                .Include(r => r.Hall)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reservationModel == null)
            {
                return NotFound();
            }

            return View(reservationModel);
        }

        // POST: Reservation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reservationModel = await _context.Reservations.FindAsync(id);
            _context.Reservations.Remove(reservationModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservationModelExists(int id)
        {
            return _context.Reservations.Any(e => e.Id == id);
        }
    }
}
