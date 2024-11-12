using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Data;

namespace WebApplication3.Controllers
{
    public class SightingsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SightingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Sightings
        public async Task<IActionResult> Index()
        {
            return View(await _context.Sightings.ToListAsync());
        }

        // GET: Sightings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sighting = await _context.Sightings
                .FirstOrDefaultAsync(m => m.SightingId == id);
            if (sighting == null)
            {
                return NotFound();
            }

            return View(sighting);
        }

        // GET: Sightings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sightings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SightingId,Date,Location")] Sighting sighting)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sighting);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sighting);
        }

        // GET: Sightings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sighting = await _context.Sightings.FindAsync(id);
            if (sighting == null)
            {
                return NotFound();
            }
            return View(sighting);
        }

        // POST: Sightings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SightingId,Date,Location")] Sighting sighting)
        {
            if (id != sighting.SightingId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sighting);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SightingExists(sighting.SightingId))
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
            return View(sighting);
        }

        // GET: Sightings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sighting = await _context.Sightings
                .FirstOrDefaultAsync(m => m.SightingId == id);
            if (sighting == null)
            {
                return NotFound();
            }

            return View(sighting);
        }

        // POST: Sightings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sighting = await _context.Sightings.FindAsync(id);
            if (sighting != null)
            {
                _context.Sightings.Remove(sighting);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SightingExists(int id)
        {
            return _context.Sightings.Any(e => e.SightingId == id);
        }
    }
}
