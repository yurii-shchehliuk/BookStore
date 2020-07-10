﻿using System;
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
    public class GanresController : Controller
    {
        private readonly TestAppContext _context;

        public GanresController(TestAppContext context)
        {
            _context = context;
        }

        // GET: Ganres
        public async Task<IActionResult> Index()
        {
            return View(await _context.Ganres.ToListAsync());
        }

        // GET: Ganres/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ganre = await _context.Ganres
                .FirstOrDefaultAsync(m => m.GanreId == id);
            if (ganre == null)
            {
                return NotFound();
            }

            return View(ganre);
        }

        // GET: Ganres/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ganres/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GanreId,GanreName")] Ganre ganre)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ganre);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ganre);
        }

        // GET: Ganres/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ganre = await _context.Ganres.FindAsync(id);
            if (ganre == null)
            {
                return NotFound();
            }
            return View(ganre);
        }

        // POST: Ganres/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GanreId,GanreName")] Ganre ganre)
        {
            if (id != ganre.GanreId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ganre);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GanreExists(ganre.GanreId))
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
            return View(ganre);
        }

        // GET: Ganres/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ganre = await _context.Ganres
                .FirstOrDefaultAsync(m => m.GanreId == id);
            if (ganre == null)
            {
                return NotFound();
            }

            return View(ganre);
        }

        // POST: Ganres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ganre = await _context.Ganres.FindAsync(id);
            _context.Ganres.Remove(ganre);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GanreExists(int id)
        {
            return _context.Ganres.Any(e => e.GanreId == id);
        }
    }
}
