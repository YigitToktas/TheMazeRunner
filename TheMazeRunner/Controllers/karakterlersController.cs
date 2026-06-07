using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TheMazeRunner.Data;
using TheMazeRunner.Models;

namespace TheMazeRunner.Controllers
{
    public class karakterlersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public karakterlersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: karakterlers
        public async Task<IActionResult> Index()
        {
            return View(await _context.karakterler.ToListAsync());
        }

        // GET: karakterlers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var karakterler = await _context.karakterler
                .FirstOrDefaultAsync(m => m.Id == id);
            if (karakterler == null)
            {
                return NotFound();
            }

            return View(karakterler);
        }

        // GET: karakterlers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: karakterlers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,isim,taraf")] karakterler karakterler)
        {
            if (ModelState.IsValid)
            {
                _context.Add(karakterler);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(karakterler);
        }

        // GET: karakterlers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var karakterler = await _context.karakterler.FindAsync(id);
            if (karakterler == null)
            {
                return NotFound();
            }
            return View(karakterler);
        }

        // POST: karakterlers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,isim,taraf")] karakterler karakterler)
        {
            if (id != karakterler.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(karakterler);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!karakterlerExists(karakterler.Id))
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
            return View(karakterler);
        }

        // GET: karakterlers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var karakterler = await _context.karakterler
                .FirstOrDefaultAsync(m => m.Id == id);
            if (karakterler == null)
            {
                return NotFound();
            }

            return View(karakterler);
        }

        // POST: karakterlers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var karakterler = await _context.karakterler.FindAsync(id);
            if (karakterler != null)
            {
                _context.karakterler.Remove(karakterler);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool karakterlerExists(int id)
        {
            return _context.karakterler.Any(e => e.Id == id);
        }
    }
}
