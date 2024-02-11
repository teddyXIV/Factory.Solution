using System.ComponentModel.DataAnnotations;

namespace Factory.Models;

public class Inspection
{
    public int InspectionId { get; set; }
    [Required(ErrorMessage = "You must provide an inspection date.")]
    public DateTime Date { get; set; }
    [Required(ErrorMessage = "You must select an inspecting engineer.")]
    public string Inspector { get; set; }
    public int MachineId { get; set; }
    public Machine Machine { get; set; }
}