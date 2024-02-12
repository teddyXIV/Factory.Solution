using Microsoft.AspNetCore.Mvc;
using Factory.Models;

namespace Factory.Controllers;

public class InspectionsController : Controller
{
    private readonly FactoryContext _db;
    public InspectionsController(FactoryContext db)
    {
        _db = db;
    }

    [HttpPost]
    public ActionResult Create(Inspection inspec)
    {
        _db.Inspections.Add(inspec);
        _db.SaveChanges();
        return RedirectToAction("Details", "Machines", new { id = inspec.MachineId });

    }
}