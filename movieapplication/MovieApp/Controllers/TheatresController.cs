using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieApp.Data;
using MovieApp.Models;

namespace MovieApp.Controllers
{
    public class TheatresController : Controller
    {
        private readonly MovieAppContext _context;

        public TheatresController(MovieAppContext context)
        {
            _context = context;
        }

        // GET: Theatres
        public async Task<IActionResult> Index()
        {
            var movieAppContext = _context.Theatre.Include(t => t.Location).Include(t => t.Movie);
            return View(await movieAppContext.ToListAsync());
        }

        // GET: Theatres/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var theatre = await _context.Theatre
                .Include(t => t.Location)
                .Include(t => t.Movie)
                .FirstOrDefaultAsync(m => m.TheatreId == id);
            if (theatre == null)
            {
                return NotFound();
            }

            return View(theatre);
        }

        // GET: Theatres/Create
        public IActionResult Create()
        {
            ViewData["LocationId"] = new SelectList(_context.Loaction, "LocationId", "LocationName");
            ViewData["MovieId"] = new SelectList(_context.Movie, "MovieId", "Description");
            return View();
        }

        // POST: Theatres/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TheatreId,TheatreName,LocationId,MovieId")] Theatre theatre)
        {
            if (ModelState.IsValid)
            {
                _context.Add(theatre);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LocationId"] = new SelectList(_context.Loaction, "LocationId", "LocationName", theatre.LocationId);
            ViewData["MovieId"] = new SelectList(_context.Movie, "MovieId", "Description", theatre.MovieId);
            return View(theatre);
        }

        // GET: Theatres/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var theatre = await _context.Theatre.FindAsync(id);
            if (theatre == null)
            {
                return NotFound();
            }
            ViewData["LocationId"] = new SelectList(_context.Loaction, "LocationId", "LocationName", theatre.LocationId);
            ViewData["MovieId"] = new SelectList(_context.Movie, "MovieId", "Description", theatre.MovieId);
            return View(theatre);
        }

        // POST: Theatres/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TheatreId,TheatreName,LocationId,MovieId")] Theatre theatre)
        {
            if (id != theatre.TheatreId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(theatre);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TheatreExists(theatre.TheatreId))
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
            ViewData["LocationId"] = new SelectList(_context.Loaction, "LocationId", "LocationName", theatre.LocationId);
            ViewData["MovieId"] = new SelectList(_context.Movie, "MovieId", "Description", theatre.MovieId);
            return View(theatre);
        }

        // GET: Theatres/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var theatre = await _context.Theatre
                .Include(t => t.Location)
                .Include(t => t.Movie)
                .FirstOrDefaultAsync(m => m.TheatreId == id);
            if (theatre == null)
            {
                return NotFound();
            }

            return View(theatre);
        }

        // POST: Theatres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var theatre = await _context.Theatre.FindAsync(id);
            _context.Theatre.Remove(theatre);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TheatreExists(int id)
        {
            return _context.Theatre.Any(e => e.TheatreId == id);
        }
    }
}
