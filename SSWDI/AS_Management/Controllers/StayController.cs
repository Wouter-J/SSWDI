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
    public class StayController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StayController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Stay
        public async Task<IActionResult> Index()
        {
            return View(await _context.Stays.ToListAsync());
        }

        // GET: Stay/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stay = await _context.Stays
                .FirstOrDefaultAsync(m => m.ID == id);
            if (stay == null)
            {
                return NotFound();
            }

            return View(stay);
        }

        // GET: Stay/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Stay/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ArrivalDate,AdoptionDate,CanBeAdopted,AdoptedBy")] Stay stay)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stay);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(stay);
        }

        // GET: Stay/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stay = await _context.Stays.FindAsync(id);
            if (stay == null)
            {
                return NotFound();
            }
            return View(stay);
        }

        // POST: Stay/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ArrivalDate,AdoptionDate,CanBeAdopted,AdoptedBy")] Stay stay)
        {
            if (id != stay.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stay);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StayExists(stay.ID))
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
            return View(stay);
        }

        // GET: Stay/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stay = await _context.Stays
                .FirstOrDefaultAsync(m => m.ID == id);
            if (stay == null)
            {
                return NotFound();
            }

            return View(stay);
        }

        // POST: Stay/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var stay = await _context.Stays.FindAsync(id);
            _context.Stays.Remove(stay);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StayExists(int id)
        {
            return _context.Stays.Any(e => e.ID == id);
        }
    }
}
