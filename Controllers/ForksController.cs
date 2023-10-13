using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ForkCraft.Data;
using ForkCraft.Models;

namespace ForkCraft.Controllers
{
    public class ForksController : Controller
    {
        private readonly ForkCraftContext _context;

        public ForksController(ForkCraftContext context)
        {
            _context = context;
        }

        // GET: Forks
        public async Task<IActionResult> Index(string forkMaterial, string searchString)
        {
            IQueryable<string> materialQuery = from m in _context.Fork
                                            orderby m.Material
                                            select m.Material;
            var forks = from m in _context.Fork
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                forks = forks.Where(s => s.Type.Contains(searchString));
            }
            if (!string.IsNullOrEmpty(forkMaterial))
            {
                forks = forks.Where(x => x.Material == forkMaterial);
            }

            var forkMaterialVM = new ForkMaterialViewModel
            {
                Material = new SelectList(await materialQuery.Distinct().ToListAsync()),
                Forks = await forks.ToListAsync()
            };
            return View(forkMaterialVM);
        }
        // GET: Forks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fork = await _context.Fork
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fork == null)
            {
                return NotFound();
            }

            return View(fork);
        }

        // GET: Forks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Forks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Type,Material,Finishing,HandleDesign,Price")] Fork fork)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fork);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fork);
        }

        // GET: Forks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fork = await _context.Fork.FindAsync(id);
            if (fork == null)
            {
                return NotFound();
            }
            return View(fork);
        }

        // POST: Forks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Type,Material,Finishing,HandleDesign,Price")] Fork fork)
        {
            if (id != fork.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fork);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ForkExists(fork.Id))
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
            return View(fork);
        }

        // GET: Forks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fork = await _context.Fork
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fork == null)
            {
                return NotFound();
            }

            return View(fork);
        }

        // POST: Forks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fork = await _context.Fork.FindAsync(id);
            _context.Fork.Remove(fork);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ForkExists(int id)
        {
            return _context.Fork.Any(e => e.Id == id);
        }
    }
}
