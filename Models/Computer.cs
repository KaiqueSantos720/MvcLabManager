namespace MvcLabManager.Models;
using System.ComponentModel.DataAnnotations;

public class Computer
{
    public int? Id { get; set; }

    [Required(ErrorMessage = "Preencha o campo Ram")]
    [StringLength(5, ErrorMessage = "O campo Ram pode ter no máximo 5 caracteres")]
    public string? Ram { get; set; }
    
    [Required(ErrorMessage = "Preencha o campo Processor")]
    public string? Processor { get; set; }

    public Computer() { }

    public Computer(int id, string ram, string processor)
    {
        Id = id;
        Ram = ram;
        Processor = processor;
    }
}