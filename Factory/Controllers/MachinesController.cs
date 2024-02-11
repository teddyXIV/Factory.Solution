using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Factory.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Factory.Controllers;
public class MachinesController : Controller
{
    private readonly FactoryContext _db;
    public MachinesController(FactoryContext db)
    {
        _db = db;
    }

    public ActionResult Index()
    {
        List<Machine> mach = _db.Machines.ToList();
        return View(mach);
    }

    public ActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Create(Machine mach)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }
        else
        {
            _db.Machines.Add(mach);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }

    public ActionResult Details(int id)
    {
        Machine mach = _db.Machines
            .Include(e => e.JoinEntities)
            .ThenInclude(join => join.Engineer)
            .FirstOrDefault(m => m.MachineId == id);

        // List<int> engIds = _db.EngineerMachines.Select(em => em.EngineerId).Distinct().ToList();
        // List<Engineer> engs = _db.Engineers.Where(e => engIds.Contains(e.EngineerId)).ToList();

        // ViewBag.EngineerId = new SelectList(engs, "EngineerId", "Name");
        return View(mach);
    }

    public ActionResult Edit(int id)
    {
        Machine mach = _db.Machines.FirstOrDefault(m => m.MachineId == id);
        return View(mach);
    }

    [HttpPost]
    public ActionResult Edit(Machine mach)
    {
        _db.Machines.Update(mach);
        _db.SaveChanges();
        return RedirectToAction("Details", new { id = mach.MachineId });
    }

    public ActionResult Delete(int id)
    {
        Machine mach = _db.Machines.FirstOrDefault(m => m.MachineId == id);
        return View(mach);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
        Machine mach = _db.Machines.FirstOrDefault(m => m.MachineId == id);
        _db.Machines.Remove(mach);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    public ActionResult AddEngineer(int id)
    {
        Machine mach = _db.Machines.FirstOrDefault(m => m.MachineId == id);
        ViewBag.EngineerId = new SelectList(_db.Engineers, "EngineerId", "Name");
        return View(mach);
    }

    [HttpPost]
    public ActionResult AddEngineer(Machine mach, int engineerId)
    {
#nullable enable
        EngineerMachine? joinEntity = _db.EngineerMachines
            .FirstOrDefault(join => (join.EngineerId == engineerId && join.MachineId == mach.MachineId));
#nullable disable
        if (joinEntity == null && engineerId != 0)
        {
            _db.EngineerMachines.Add(new EngineerMachine() { EngineerId = engineerId, MachineId = mach.MachineId });
            _db.SaveChanges();
        }
        return RedirectToAction("Details", new { id = mach.MachineId });
    }

    [HttpPost]
    public ActionResult DeleteJoin(int joinId, int machId)
    {
        EngineerMachine joinEntry = _db.EngineerMachines.FirstOrDefault(entry => entry.EngineerMachineId == joinId);
        _db.EngineerMachines.Remove(joinEntry);
        _db.SaveChanges();

        return RedirectToAction("Details", new { id = machId });
    }

    [HttpPost]
    public ActionResult UpdateStatus(int id, string newStatus)
    {
        Machine mach = _db.Machines.FirstOrDefault(m => m.MachineId == id);
        mach.Status = newStatus;
        _db.Machines.Update(mach);
        _db.SaveChanges();
        return RedirectToAction("Details", new { id });

    }
}