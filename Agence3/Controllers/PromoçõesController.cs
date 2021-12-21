using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Agence3.Data;
using Agence3.Models;

namespace Agence3.Controllers
{
    public class PromoçõesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PromoçõesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Promoções
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Promoções.Include(p => p.Viagem);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Promoções/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var promoções = await _context.Promoções
                .Include(p => p.Viagem)
                .FirstOrDefaultAsync(m => m.IDPromoc == id);
            if (promoções == null)
            {
                return NotFound();
            }

            return View(promoções);
        }

        // GET: Promoções/Create
        public IActionResult Create()
        {
            ViewData["IDviagem"] = new SelectList(_context.Viagem, "IDviagem", "IDviagem");
            return View();
        }

        // POST: Promoções/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDPromoc,IDviagem,Preço_desconto")] Promoções promoções)
        {
            if (ModelState.IsValid)
            {
                _context.Add(promoções);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IDviagem"] = new SelectList(_context.Viagem, "IDviagem", "IDviagem", promoções.IDviagem);
            return View(promoções);
        }

        // GET: Promoções/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var promoções = await _context.Promoções.FindAsync(id);
            if (promoções == null)
            {
                return NotFound();
            }
            ViewData["IDviagem"] = new SelectList(_context.Viagem, "IDviagem", "IDviagem", promoções.IDviagem);
            return View(promoções);
        }

        // POST: Promoções/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IDPromoc,IDviagem,Preço_desconto")] Promoções promoções)
        {
            if (id != promoções.IDPromoc)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(promoções);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PromoçõesExists(promoções.IDPromoc))
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
            ViewData["IDviagem"] = new SelectList(_context.Viagem, "IDviagem", "IDviagem", promoções.IDviagem);
            return View(promoções);
        }

        // GET: Promoções/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var promoções = await _context.Promoções
                .Include(p => p.Viagem)
                .FirstOrDefaultAsync(m => m.IDPromoc == id);
            if (promoções == null)
            {
                return NotFound();
            }

            return View(promoções);
        }

        // POST: Promoções/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var promoções = await _context.Promoções.FindAsync(id);
            _context.Promoções.Remove(promoções);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PromoçõesExists(int id)
        {
            return _context.Promoções.Any(e => e.IDPromoc == id);
        }
    }
}
