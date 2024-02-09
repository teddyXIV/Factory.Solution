using System.ComponentModel.DataAnnotations;
namespace Factory.Models;

public class Engineer
{
    public int EngineerId { get; set; }
    [Required(ErrorMessage = "You must provide an engineer name.")]
    public string Name { get; set; }
    [Required(ErrorMessage = "You must provide an engineer specialty.")]
    public string Specialty { get; set; }
    public List<EngineerMachine> JoinEntities { get; }
}