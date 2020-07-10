using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Domain;
using Domain.Entities;

namespace Dashboard.Web.Controllers
{
    public class BookGanresController : Controller
    {
        private readonly TestAppContext _context;

        public BookGanresController(TestAppContext context)
        {
            _context = context;
        }

        // GET: BookGanres
        public async Task<IActionResult> Index()
        {
            var testAppContext = _context.BookGanres.Include(b => b.Book).Include(b => b.Ganre);
            return View(await testAppContext.ToListAsync());
        }

        // GET: BookGanres/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookGanre = await _context.BookGanres
                .Include(b => b.Book)
                .Include(b => b.Ganre)
                .FirstOrDefaultAsync(m => m.BookId == id);
            if (bookGanre == null)
            {
                return NotFound();
            }

            return View(bookGanre);
        }

        // GET: BookGanres/Create
        public IActionResult Create()
        {
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "BookId");
            ViewData["GanreId"] = new SelectList(_context.Ganres, "GanreId", "GanreId");
            return View();
        }

        // POST: BookGanres/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookId,GanreId")] BookGanre bookGanre)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookGanre);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "BookId", bookGanre.BookId);
            ViewData["GanreId"] = new SelectList(_context.Ganres, "GanreId", "GanreId", bookGanre.GanreId);
            return View(bookGanre);
        }

        // GET: BookGanres/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookGanre = await _context.BookGanres.FindAsync(id);
            if (bookGanre == null)
            {
                return NotFound();
            }
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "BookId", bookGanre.BookId);
            ViewData["GanreId"] = new SelectList(_context.Ganres, "GanreId", "GanreId", bookGanre.GanreId);
            return View(bookGanre);
        }

        // POST: BookGanres/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookId,GanreId")] BookGanre bookGanre)
        {
            if (id != bookGanre.BookId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookGanre);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookGanreExists(bookGanre.BookId))
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
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "BookId", bookGanre.BookId);
            ViewData["GanreId"] = new SelectList(_context.Ganres, "GanreId", "GanreId", bookGanre.GanreId);
            return View(bookGanre);
        }

        // GET: BookGanres/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookGanre = await _context.BookGanres
                .Include(b => b.Book)
                .Include(b => b.Ganre)
                .FirstOrDefaultAsync(m => m.BookId == id);
            if (bookGanre == null)
            {
                return NotFound();
            }

            return View(bookGanre);
        }

        // POST: BookGanres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bookGanre = await _context.BookGanres.FindAsync(id);
            _context.BookGanres.Remove(bookGanre);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookGanreExists(int id)
        {
            return _context.BookGanres.Any(e => e.BookId == id);
        }
    }
}
