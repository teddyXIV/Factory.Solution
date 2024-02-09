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

}