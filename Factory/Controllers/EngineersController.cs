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

    [HttpPost]
    public ActionResult Edit(Engineer eng)
    {
        _db.Engineers.Update(eng);
        _db.SaveChanges();
        return RedirectToAction("Details", new { id = eng.EngineerId });
    }

    public ActionResult Delete(int id)
    {
        Engineer eng = _db.Engineers.FirstOrDefault(e => e.EngineerId == id);
        return View(eng);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
        Engineer eng = _db.Engineers.FirstOrDefault(e => e.EngineerId == id);
        _db.Engineers.Remove(eng);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    public ActionResult AddMachine(int id)
    {
        Engineer eng = _db.Engineers.FirstOrDefault(e => e.EngineerId == id);
        ViewBag.MachineId = new SelectList(_db.Machines, "MachineId", "Name");
        return View(eng);
    }

    [HttpPost]
    public ActionResult AddMachine(Engineer eng, int machineId)
    {
#nullable enable
        EngineerMachine? joinEntity = _db.EngineerMachines
            .FirstOrDefault(join => (join.MachineId == machineId && join.EngineerId == eng.EngineerId));
#nullable disable
        if (joinEntity == null && machineId != 0)
        {
            _db.EngineerMachines.Add(new EngineerMachine() { MachineId = machineId, EngineerId = eng.EngineerId });
            _db.SaveChanges();
        }
        return RedirectToAction("Details", new { id = eng.EngineerId });
    }

    [HttpPost]
    public ActionResult DeleteJoin(int joinId, int engId)
    {
        EngineerMachine joinEntry = _db.EngineerMachines.FirstOrDefault(entry => entry.EngineerMachineId == joinId);
        _db.EngineerMachines.Remove(joinEntry);
        _db.SaveChanges();

        return RedirectToAction("Details", new { id = engId });
    }
}