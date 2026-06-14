using BibliotekaMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BibliotekaMVC.Data;

namespace BibliotekaMVC.Controllers
{
    public class ZaduzenjeController : Controller
    {
        private readonly BibliotekaContext _context;

        public ZaduzenjeController(BibliotekaContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var zaduzenja = await _context.Zaduzenja
                .Include(z => z.Knjiga)
                .Include(z => z.Clan)
                .ToListAsync();

            return View(zaduzenja);
        }

        public IActionResult Create()
        {
            ViewBag.Knjige = _context.Knjige
                .Where(k => k.Dostupna)
                .ToList();

            return View();
        }

        public IActionResult VratiForm(int id)
        {
            return View(id);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Zaduzenje z, string Ime, string Prezime, string Email)
        {
            z.DatumZaduzenja = DateTime.Now;
            z.Vraceno = false;

            if (string.IsNullOrWhiteSpace(Email) || !Email.Contains("@"))
            {
                ModelState.AddModelError("", "Email nije ispravno unet.");
                ViewBag.Knjige = _context.Knjige.Where(k => k.Dostupna).ToList();
                return View();
            }

            var clan = _context.Clanovi.FirstOrDefault(c => c.Email == Email);

            if (clan == null)
            {
                clan = new Clan
                {
                    Ime = Ime,
                    Prezime = Prezime,
                    Email = Email
                };

                _context.Clanovi.Add(clan);
                await _context.SaveChangesAsync();
            }

            var knjiga = await _context.Knjige.FindAsync(z.KnjigaId);

            if (knjiga == null || !knjiga.Dostupna)
            {
                ModelState.AddModelError("", "Knjiga nije dostupna.");
                ViewBag.Knjige = _context.Knjige.Where(k => k.Dostupna).ToList();
                return View();
            }

            knjiga.Dostupna = false;
            z.ClanId = clan.Id;

            _context.Zaduzenja.Add(z);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Vrati(int id, string email)
        {
            var zaduzenje = await _context.Zaduzenja
                .Include(z => z.Knjiga)
                .Include(z => z.Clan)
                .FirstOrDefaultAsync(z => z.Id == id);

            if (zaduzenje == null)
                return NotFound();

            if (zaduzenje.Clan.Email != email)
            {
                ModelState.AddModelError("", "Pogrešan email.");
                return View("VratiForm", id);
            }

            zaduzenje.Vraceno = true;
            zaduzenje.DatumVracanja = DateTime.Now;
            zaduzenje.Knjiga.Dostupna = true;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}