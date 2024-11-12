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
    public class JacketOwnersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public JacketOwnersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: JacketOwners
        public async Task<IActionResult> Index()
        {
            return View(await _context.JacketOwners.ToListAsync());
        }

        // GET: JacketOwners/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jacketOwner = await _context.JacketOwners
                .FirstOrDefaultAsync(m => m.JacketOwnerId == id);
            if (jacketOwner == null)
            {
                return NotFound();
            }

            return View(jacketOwner);
        }

        // GET: JacketOwners/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: JacketOwners/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("JacketOwnerId,FirstName,LastName,Contact")] JacketOwner jacketOwner)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jacketOwner);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jacketOwner);
        }

        // GET: JacketOwners/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jacketOwner = await _context.JacketOwners.FindAsync(id);
            if (jacketOwner == null)
            {
                return NotFound();
            }
            return View(jacketOwner);
        }

        // POST: JacketOwners/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("JacketOwnerId,FirstName,LastName,Contact")] JacketOwner jacketOwner)
        {
            if (id != jacketOwner.JacketOwnerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jacketOwner);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JacketOwnerExists(jacketOwner.JacketOwnerId))
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
            return View(jacketOwner);
        }

        // GET: JacketOwners/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jacketOwner = await _context.JacketOwners
                .FirstOrDefaultAsync(m => m.JacketOwnerId == id);
            if (jacketOwner == null)
            {
                return NotFound();
            }

            return View(jacketOwner);
        }

        // POST: JacketOwners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jacketOwner = await _context.JacketOwners.FindAsync(id);
            if (jacketOwner != null)
            {
                _context.JacketOwners.Remove(jacketOwner);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JacketOwnerExists(int id)
        {
            return _context.JacketOwners.Any(e => e.JacketOwnerId == id);
        }
    }
}
