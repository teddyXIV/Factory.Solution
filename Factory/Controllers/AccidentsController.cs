using Microsoft.AspNetCore.Mvc;
using Factory.Models;

namespace Factory.Controllers;

public class AccidentsController : Controller
{
    private readonly FactoryContext _db;
    public AccidentsController(FactoryContext db)
    {
        _db = db;
    }

    [HttpPost]
    public ActionResult Create(Accident acc)
    {
        _db.Accidents.Add(acc);
        _db.SaveChanges();
        return RedirectToAction("Details", "Engineers", new { id = acc.EngineerId });

    }
}