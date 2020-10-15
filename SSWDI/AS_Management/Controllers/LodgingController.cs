using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AS_Core.DomainModel;
using AS_EFShelterData;

namespace AS_Management.Controllers
{
    public class LodgingController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LodgingController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Lodging
        public async Task<IActionResult> Index()
        {
            return View(await _context.Lodgings.ToListAsync());
        }

        // GET: Lodging/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lodging = await _context.Lodgings
                .FirstOrDefaultAsync(m => m.ID == id);
            if (lodging == null)
            {
                return NotFound();
            }

            return View(lodging);
        }

        // GET: Lodging/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Lodging/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,LodgingType,MaxCapacity,AnimalType")] Lodging lodging)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lodging);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lodging);
        }

        // GET: Lodging/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lodging = await _context.Lodgings.FindAsync(id);
            if (lodging == null)
            {
                return NotFound();
            }
            return View(lodging);
        }

        // POST: Lodging/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,LodgingType,MaxCapacity,AnimalType")] Lodging lodging)
        {
            if (id != lodging.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lodging);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LodgingExists(lodging.ID))
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
            return View(lodging);
        }

        // GET: Lodging/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lodging = await _context.Lodgings
                .FirstOrDefaultAsync(m => m.ID == id);
            if (lodging == null)
            {
                return NotFound();
            }

            return View(lodging);
        }

        // POST: Lodging/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lodging = await _context.Lodgings.FindAsync(id);
            _context.Lodgings.Remove(lodging);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LodgingExists(int id)
        {
            return _context.Lodgings.Any(e => e.ID == id);
        }
    }
}
