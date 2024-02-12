using System.ComponentModel.DataAnnotations;

namespace Factory.Models;

public class Inspection
{
    public int InspectionId { get; set; }
    public DateTime Date { get; set; }
    public string Inspector { get; set; }
    public int MachineId { get; set; }
    public Machine Machine { get; set; }
}