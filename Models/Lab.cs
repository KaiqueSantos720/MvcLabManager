namespace MvcLabManager.Models;
using System.ComponentModel.DataAnnotations;

public class Lab
{
    public int? Id { get; set; }

    [Required(ErrorMessage = "Preencha o campo Number")]
    [Range(1, 100, ErrorMessage = "O campo Number necessita estar no intervalo de 1 a 100")]
    public int? Number { get; set; }

    [Required(ErrorMessage = "Preencha o campo Name")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Preencha o campo Block")]
    [StringLength(1, ErrorMessage = "O campo Block pode ter no máximo 1 caracter")]
    public string? Block { get; set; }

    public Lab() { }

    public Lab(int id, int number, string name, string block)
    {
        Id = id;
        Number = number;
        Name = name;
        Block = block;
    }
}