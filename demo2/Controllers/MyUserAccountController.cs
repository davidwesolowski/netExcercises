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
    public class MyUserAccountController : Controller
    {
        private readonly PrimaryContext _context;

        public MyUserAccountController(PrimaryContext context)
        {
            _context = context;
        }

        // GET: MyUserAccount
        public async Task<IActionResult> Index()
        {
            return View(await _context.MyUserAccounts.ToListAsync());
        }

        // GET: MyUserAccount/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myUserAccount = await _context.MyUserAccounts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (myUserAccount == null)
            {
                return NotFound();
            }

            return View(myUserAccount);
        }

        // GET: MyUserAccount/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MyUserAccount/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Address,Nickname,UserName,NormalizedUserName,Email,NormalizedEmail,EmailConfirmed,PasswordHash,SecurityStamp,ConcurrencyStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnd,LockoutEnabled,AccessFailedCount")] MyUserAccount myUserAccount)
        {
            if (ModelState.IsValid)
            {
                _context.Add(myUserAccount);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(myUserAccount);
        }

        // GET: MyUserAccount/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myUserAccount = await _context.MyUserAccounts.FindAsync(id);
            if (myUserAccount == null)
            {
                return NotFound();
            }
            return View(myUserAccount);
        }

        // POST: MyUserAccount/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Address,Nickname,UserName,NormalizedUserName,Email,NormalizedEmail,EmailConfirmed,PasswordHash,SecurityStamp,ConcurrencyStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnd,LockoutEnabled,AccessFailedCount")] MyUserAccount myUserAccount)
        {
            if (id != myUserAccount.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(myUserAccount);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MyUserAccountExists(myUserAccount.Id))
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
            return View(myUserAccount);
        }

        // GET: MyUserAccount/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myUserAccount = await _context.MyUserAccounts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (myUserAccount == null)
            {
                return NotFound();
            }

            return View(myUserAccount);
        }

        // POST: MyUserAccount/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var myUserAccount = await _context.MyUserAccounts.FindAsync(id);
            _context.MyUserAccounts.Remove(myUserAccount);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MyUserAccountExists(string id)
        {
            return _context.MyUserAccounts.Any(e => e.Id == id);
        }
    }
}
