using System.ComponentModel.DataAnnotations;
namespace Factory.Models;

public class Machine
{
    public int MachineId { get; set; }
    [Required(ErrorMessage = "You must provide a machine name.")]
    public string Name { get; set; }
    [Required(ErrorMessage = "You must provide a machine function.")]
    public string Function { get; set; }
    public string Status { get; set; } = "Functioning normally";
    public List<EngineerMachine> JoinEntities { get; }
}