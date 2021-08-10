using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using youBox.Data;
using youBox.Models;

namespace youBox.Controllers
{
    public class SubscribersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SubscribersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Subscribers
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Subscribers.Include(s => s.IdentityUser);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Subscribers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subscriber = await _context.Subscribers
                .Include(s => s.IdentityUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subscriber == null)
            {
                return NotFound();
            }

            return View(subscriber);
        }

        // GET: Subscribers/Create
        public IActionResult Create()
        {
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Subscribers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,AddressLine1,AddressLine2,City,State,ZipCode,PhoneNumber,Package,IdentityUserId")] Subscriber subscriber)
        {
            if (ModelState.IsValid)
            {
                _context.Add(subscriber);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", subscriber.IdentityUserId);
            return View(subscriber);
        }

        // GET: Subscribers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subscriber = await _context.Subscribers.FindAsync(id);
            if (subscriber == null)
            {
                return NotFound();
            }
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", subscriber.IdentityUserId);
            return View(subscriber);
        }

        // POST: Subscribers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,AddressLine1,AddressLine2,City,State,ZipCode,PhoneNumber,Package,IdentityUserId")] Subscriber subscriber)
        {
            if (id != subscriber.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subscriber);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubscriberExists(subscriber.Id))
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
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", subscriber.IdentityUserId);
            return View(subscriber);
        }

        // GET: Subscribers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subscriber = await _context.Subscribers
                .Include(s => s.IdentityUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subscriber == null)
            {
                return NotFound();
            }

            return View(subscriber);
        }

        // POST: Subscribers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var subscriber = await _context.Subscribers.FindAsync(id);
            _context.Subscribers.Remove(subscriber);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubscriberExists(int id)
        {
            return _context.Subscribers.Any(e => e.Id == id);
        }

        public ActionResult ClothingSurvey (int id)
        {
            List<SelectListItem> Style = new List<SelectListItem>()
            {
                new SelectListItem {Text="Casual", Value="Casual"},
                new SelectListItem {Text="Athletic", Value="Athletic"},
                new SelectListItem {Text="Formal", Value="Formal"},
            };
            List<SelectListItem> Colors = new List<SelectListItem>()
            {
                new SelectListItem {Text="Dark", Value="Dark"},
                new SelectListItem {Text="Blue", Value="Blue"},
                new SelectListItem {Text="Orange", Value="Orange"},
            };
            List<SelectListItem> ShirtSize = new List<SelectListItem>()
            {
                new SelectListItem {Text="Small", Value="Small"},
                new SelectListItem {Text="Medium", Value="Medium"},
                new SelectListItem {Text="Large", Value="Large"},
                 new SelectListItem {Text="Extra Large", Value="ExtraLarge"},
            };
            List<SelectListItem> PantSize = new List<SelectListItem>()
            {
                new SelectListItem {Text="Casual", Value="Casual"},
                new SelectListItem {Text="Athletic", Value="Athletic"},
                new SelectListItem {Text="Formal", Value="Formal"},
            };
            List<SelectListItem> Hats = new List<SelectListItem>()
            {
                new SelectListItem {Text="Yes", Value="Yes"},
                new SelectListItem {Text="No", Value="No"},
               
            };
            List<SelectListItem> Shorts = new List<SelectListItem>()
            {
                new SelectListItem {Text="Yes", Value="Yes"},
                new SelectListItem {Text="No", Value="No"},
                
            };
            List<SelectListItem> SecondaryStyle = new List<SelectListItem>()
            {
                new SelectListItem {Text="Casual", Value="Casual"},
                new SelectListItem {Text="Athletic", Value="Athletic"},
                new SelectListItem {Text="Formal", Value="Formal"},
            };
            var survey = _context.ClothingSurveys.Where(s => s.SubscriberId == id).FirstOrDefault();
            ViewBag.Style = Style;
            ViewBag.Colors = Colors;
            ViewBag.ShirtSize = ShirtSize;
            ViewBag.PantSize = PantSize;
            ViewBag.Hats = Hats;
            ViewBag.Shorts = Shorts;
            ViewBag.SecondaryStyle = SecondaryStyle;
            return View(survey);
        }
        [HttpPost]
        public ActionResult ClothingSurvey (ClothingSurvey clothingSurvey)
        {
            _context.ClothingSurveys.Update(clothingSurvey);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
