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
}