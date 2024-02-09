using System.ComponentModel.DataAnnotations;
namespace Factory.Models;

public class Machine
{
    public int MachineId { get; set; }
    [Required(ErrorMessage = "You must provide a machine name.")]
    public string Name { get; set; }
    [Required(ErrorMessage = "You must provide a machine purpose.")]
    public string Purpose { get; set; }
    public List<EngineerMachine> JoinEntities { get; }
}