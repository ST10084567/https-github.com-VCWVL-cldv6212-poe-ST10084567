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
    public class JacketsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public JacketsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Jackets
        public async Task<IActionResult> Index()
        {
            return View(await _context.Jackets.ToListAsync());
        }

        // GET: Jackets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jacket = await _context.Jackets
                .FirstOrDefaultAsync(m => m.JacketId == id);
            if (jacket == null)
            {
                return NotFound();
            }

            return View(jacket);
        }

        // GET: Jackets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Jackets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("JacketId,Color,Size,Material")] Jacket jacket)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jacket);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jacket);
        }

        // GET: Jackets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jacket = await _context.Jackets.FindAsync(id);
            if (jacket == null)
            {
                return NotFound();
            }
            return View(jacket);
        }

        // POST: Jackets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("JacketId,Color,Size,Material")] Jacket jacket)
        {
            if (id != jacket.JacketId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jacket);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JacketExists(jacket.JacketId))
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
            return View(jacket);
        }

        // GET: Jackets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jacket = await _context.Jackets
                .FirstOrDefaultAsync(m => m.JacketId == id);
            if (jacket == null)
            {
                return NotFound();
            }

            return View(jacket);
        }

        // POST: Jackets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jacket = await _context.Jackets.FindAsync(id);
            if (jacket != null)
            {
                _context.Jackets.Remove(jacket);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JacketExists(int id)
        {
            return _context.Jackets.Any(e => e.JacketId == id);
        }
    }
}
