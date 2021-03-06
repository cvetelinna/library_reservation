using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using library_reservation.Data;
using library_reservation.Models;
using Microsoft.AspNetCore.Authorization;

namespace library_reservation.Controllers
{
    public class ReservationController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReservationController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Reservation
        [Authorize]
        public async Task<IActionResult> Index([FromQuery]string searchQuery)
        {
            if (User.IsInRole("Admin"))
            {
                var reservations = await _context.Reservations
                    .Include(r => r.Hall)
                    .ToListAsync();

                if (!string.IsNullOrEmpty(searchQuery))
                {
                    reservations = reservations
                        .Where(r => 
                            r.Subject.Normalize().Contains(searchQuery.Normalize()))
                        .ToList();
                }
                return View(reservations);
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userReservations = await _context.Reservations
                .Include(r => r.Hall)
                .Where(r => r.UserId == userId)
                .ToListAsync();

            return View(userReservations);
        }

        // GET: Reservation/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservationModel = await _context.Reservations
                .Include(r => r.Hall)
                .Include(r => r.RecurringSettings
                )
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reservationModel == null)
            {
                return NotFound();
            }

            return View(reservationModel);
        }

        // GET: Reservation/Create
        [Authorize]
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
        [Authorize]
        public async Task<IActionResult> Create(
            [Bind("Id,HallId,UserId,StartDate,EndDate,Subject,Organizers,Description,RequiresMultimedia,RecurringSettingsId,IsRecurring")] ReservationModel reservationModel, 
            [Bind("Id,RecurrenceType,RecurrenceStartDate,EndType,EndCounter,RecurrenceEndDate,RecurrinMonths,RecurringDays")] RecurringSettings recurrenceSettings)
        {
            if (reservationModel.IsRecurring)
            {
                if (recurrenceSettings.RecurrenceEndDate != null)
                {
                    var compare = DateTime.Compare(reservationModel.StartDate, (DateTime) recurrenceSettings.RecurrenceEndDate);
                    if (compare > 0)
                    {
                        ModelState.AddModelError("RecurrenceEndDate", "End date should be after the initial event start date");
                    }
                }
                
                reservationModel.RecurringSettings = recurrenceSettings;
            }

            var start = reservationModel.StartDate;
            var end = reservationModel.EndDate;
            var result = DateTime.Compare(start, end);
            if (result > 0)
            {
                ModelState.AddModelError("StartDate", "Start date should be before the end date");
            }

            var overlappingReservation = _context.Reservations
                .Where(r => r.HallId == reservationModel.HallId)
                .Any(r =>
                    reservationModel.StartDate < r.EndDate &&
                    reservationModel.EndDate > r.StartDate);

            if (overlappingReservation)
            {
                ModelState.AddModelError("StartDate", "Reservation overlaps with existing event");
            }
            
            var overlappingReservations = _context.Reservations
                .Where(r => r.HallId == reservationModel.HallId)
                .Any(r => 
                    reservationModel.StartDate < r.EndDate && 
                    reservationModel.EndDate > r.StartDate);
            if (overlappingReservations)
            {
                ModelState.AddModelError("StartDate", "Reservation overlaps with existing event");
            }
            
            if (!ModelState.IsValid)
            {
                ViewData["HallId"] = new SelectList(_context.Halls, "Id", "Name", reservationModel.HallId);
                return View();
            }

            reservationModel.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            _context.Add(reservationModel);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: Reservation/Edit/5
        [Authorize(Roles = "Admin")]
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

            ViewData["HallId"] = new SelectList(_context.Halls, "Id", "Name", reservationModel.HallId);
            return View(reservationModel);
        }

        // POST: Reservation/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,HallId,UserId,StartDate,EndDate,Subject,Organizers,Description,RequiresMultimedia")] ReservationModel reservationModel)
        {
            if (id != reservationModel.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                ViewData["HallId"] = new SelectList(_context.Halls, "Id", "Id", reservationModel.HallId);
                return View(reservationModel);
            }

            _context.Update(reservationModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Reservation/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservationModel = await _context.Reservations
                .Include(r => r.Hall)
                .Include(r => r.RecurringSettings)
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
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reservationModel = await _context.Reservations.FindAsync(id);
            
            if (reservationModel.IsRecurring)
            {
                var recurringSettings = await _context.RecurringSettings.FindAsync(reservationModel.RecurringSettingsId);
                _context.RecurringSettings.Remove(recurringSettings);
            }

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
