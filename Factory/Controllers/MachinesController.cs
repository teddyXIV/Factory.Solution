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
}