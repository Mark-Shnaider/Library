using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Library.Models;

namespace Library.Controllers
{
    public class ReaderController:Controller
    {
        LibraryContext db;

        public ReaderController(LibraryContext context)
        {
            db = context;
        }

        
        public async Task<IActionResult> Index(string SearchString)
        {
            IQueryable<Reader> readers = db.Readers;

            if (!string.IsNullOrEmpty(SearchString))
            {
                readers = readers.Where(r => r.Name.Contains(SearchString));
            }
            return View(await readers.ToListAsync());
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id, Name, BirthDate")] Reader reader)
        {
            if (ModelState.IsValid)
            {
                db.Add(reader);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reader);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reader = await db.Readers.FirstOrDefaultAsync(m => m.Id == id);

            if (reader == null)
            {
                return NotFound();
            }

            return View(reader);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reader = await db.Readers.FindAsync(id);
            if (reader == null)
            {
                return NotFound();
            }
            return View(reader);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id, Name, BirthDate")] Reader reader)
        {
            if (id != reader.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(reader);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (db.Readers.Any(e => e.Id == reader.Id))
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
            return View(reader);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reader = await db.Readers.FirstOrDefaultAsync(r=> r.Id == id);

            if (reader == null)
            {
                return NotFound();
            }

            return View(reader);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reader = await db.Readers.FindAsync(id);
            db.Readers.Remove(reader);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
