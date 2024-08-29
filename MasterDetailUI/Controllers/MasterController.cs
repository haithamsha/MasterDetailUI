using MasterDetailUI.Data;
using MasterDetailUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MasterDetailUI.Controllers
{
    public class MasterController : Controller
    {
        private readonly AppDbContext _context;

        public MasterController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Masters.Include(m => m.Details).ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Master master)
        {
            ModelState.Remove("Master");
            ModelState.Remove("Details.Master");

            if (ModelState.IsValid)
            {
                _context.Add(master);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(master);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var master = await _context.Masters.Include(m => m.Details).FirstOrDefaultAsync(m => m.Id == id);
            if (master == null)
            {
                return NotFound();
            }
            return View(master);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Master master)
        {
            if (id != master.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(master);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MasterExists(master.Id))
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
            return View(master);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var master = await _context.Masters
                .FirstOrDefaultAsync(m => m.Id == id);
            if (master == null)
            {
                return NotFound();
            }

            return View(master);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var master = await _context.Masters.FindAsync(id);
            _context.Masters.Remove(master);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MasterExists(int id)
        {
            return _context.Masters.Any(e => e.Id == id);
        }
    }
}
