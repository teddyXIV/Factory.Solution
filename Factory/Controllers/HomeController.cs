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
        return View();
    }
}