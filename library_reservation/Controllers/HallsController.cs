using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using library_reservation.Data;
using library_reservation.Models;
using Microsoft.AspNetCore.Authorization;

namespace library_reservation.Controllers
{
    public class HallsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HallsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Halls
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Halls.ToListAsync());
        }

        // GET: Halls/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hall = await _context.Halls
                .FirstOrDefaultAsync(m => m.Id == id);

            var reservations = await _context.Reservations
                .Where(r => r.HallId == id)
                .Include(r => r.RecurringSettings)
                .ToListAsync();
            
            // prevent cyclical data - default from cache from route
            foreach (var reservation in reservations)
            {
                reservation.Hall = null;
                if (reservation.RecurringSettings != null)
                {
                    reservation.RecurringSettings.Reservation = null;
                }
            }
            
            if (hall == null)
            {
                return NotFound();
            }

            hall.Reservations = reservations;

            return View(hall);
        }

        // GET: Halls/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Halls/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Bind("Id,Name,Type")] Hall hall)
        {

            if (!ModelState.IsValid)
            {
                return View(hall);
            }
            _context.Add(hall);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Halls/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hall = await _context.Halls.FindAsync(id);
            if (hall == null)
            {
                return NotFound();
            }
            return View(hall);
        }

        // POST: Halls/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Type")] Hall hall)
        {
            if (id != hall.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(hall);
            }
            
            _context.Update(hall);
            await _context.SaveChangesAsync();
            
            return RedirectToAction(nameof(Index));
        }

        // GET: Halls/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hall = await _context.Halls
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hall == null)
            {
                return NotFound();
            }

            return View(hall);
        }

        // POST: Halls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hall = await _context.Halls.FindAsync(id);
            _context.Halls.Remove(hall);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
