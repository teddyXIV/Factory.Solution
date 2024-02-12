using System.ComponentModel.DataAnnotations;

namespace Factory.Models;

public class Accident
{
    public int AccidentId { get; set; }
    public DateTime Date { get; set; }
    public string Description { get; set; }
    public int EngineerId { get; set; }
    public Engineer Engineer { get; set; }
}