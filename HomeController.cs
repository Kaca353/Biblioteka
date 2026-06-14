using BibliotekaMVC.Data;


using BibliotekaMVC.Data;
using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    private readonly BibliotekaContext _context;

    public HomeController(BibliotekaContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        ViewBag.BrojKnjiga = _context.Knjige.Count();
        ViewBag.BrojZaduzenja = _context.Zaduzenja.Count();
        ViewBag.BrojDostupnih = _context.Knjige.Count(k => k.Dostupna == true);

        return View();
    }
    public IActionResult Contact()
    {
        return View();
    }
}