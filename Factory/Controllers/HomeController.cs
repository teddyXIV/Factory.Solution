using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Factory.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Factory.Controllers;
public class HomeController : Controller
{
    private readonly FactoryContext _db;
    public HomeController(FactoryContext db)
    {
        _db = db;
    }

    [HttpGet("/")]
    public ActionResult Index()
    {
        int engs = _db.Engineers.ToArray().Length;
        int machs = _db.Machines.ToArray().Length;
        int inspecs = _db.Inspections.ToArray().Length;
        int accs = _db.Accidents.ToArray().Length;
        Dictionary<string, int> model = new()
        {
            { "engs", engs },
            { "machs", machs },
            { "inspecs", inspecs },
            { "accs", accs }
        };

        return View(model);
    }
}