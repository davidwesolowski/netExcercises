using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using demo2.Persistance;
using demo2.Persistance.Entities;

namespace demo2.Controllers
{
    public class MyRoleController : Controller
    {
        private readonly PrimaryContext _context;

        public MyRoleController(PrimaryContext context)
        {
            _context = context;
        }

        // GET: MyRole
        public async Task<IActionResult> Index()
        {
            return View(await _context.MyRoles.ToListAsync());
        }

        // GET: MyRole/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myRole = await _context.MyRoles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (myRole == null)
            {
                return NotFound();
            }

            return View(myRole);
        }

        // GET: MyRole/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MyRole/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,NormalizedName,ConcurrencyStamp")] MyRole myRole)
        {
            if (ModelState.IsValid)
            {
                _context.Add(myRole);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(myRole);
        }

        // GET: MyRole/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myRole = await _context.MyRoles.FindAsync(id);
            if (myRole == null)
            {
                return NotFound();
            }
            return View(myRole);
        }

        // POST: MyRole/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Name,NormalizedName,ConcurrencyStamp")] MyRole myRole)
        {
            if (id != myRole.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(myRole);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MyRoleExists(myRole.Id))
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
            return View(myRole);
        }

        // GET: MyRole/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myRole = await _context.MyRoles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (myRole == null)
            {
                return NotFound();
            }

            return View(myRole);
        }

        // POST: MyRole/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var myRole = await _context.MyRoles.FindAsync(id);
            _context.MyRoles.Remove(myRole);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MyRoleExists(string id)
        {
            return _context.MyRoles.Any(e => e.Id == id);
        }
    }
}
