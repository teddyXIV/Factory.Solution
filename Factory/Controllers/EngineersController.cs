using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Factory.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Factory.Controllers;
public class EngineersController : Controller
{
    private readonly FactoryContext _db;
    public EngineersController(FactoryContext db)
    {
        _db = db;
    }

    public ActionResult Index()
    {
        List<Engineer> eng = _db.Engineers.ToList();
        return View(eng);
    }

    public ActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Create(Engineer eng)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }
        else
        {
            _db.Engineers.Add(eng);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }

    public ActionResult Details(int id)
    {
        Engineer eng = _db.Engineers
            .Include(e => e.JoinEntities)
            .ThenInclude(join => join.Machine)
            .FirstOrDefault(e => e.EngineerId == id);
        return View(eng);
    }

    public ActionResult Edit(int id)
    {
        Engineer eng = _db.Engineers.FirstOrDefault(e => e.EngineerId == id);
        return View(eng);
    }
}