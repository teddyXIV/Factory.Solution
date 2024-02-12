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
        Engineer[] engs = _db.Engineers.ToArray();
        Machine[] machs = _db.Machines.ToArray();
        Inspection[] inspecs = _db.Inspections.ToArray();
        Accident[] accs = _db.Accidents.ToArray();
        Dictionary<string, object[]> model = new Dictionary<string, object[]>
        {
            { "engs", engs },
            { "machs", machs },
            { "inspecs", inspecs },
            { "accs", accs }
        };

        return View(model);
    }
}