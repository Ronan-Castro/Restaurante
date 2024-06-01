using System.ComponentModel.DataAnnotations;

namespace RestaurantApp.Domain.Models;
public class Grupo
{
  
    public int Id { get; set; }

    [Required(ErrorMessage = "O campo Nome é obrigatório.")]
    [StringLength(60, ErrorMessage = "O campo Nome deve ter no máximo 60 caracteres.")]
   // [RegularExpression("^[a-zA-Z0-9 ]+$", ErrorMessage = "O campo Nome deve conter apenas letras, números e espaços.")]
    [Display(Name = "Nome da Categoria")]
    public string Nome { get; set; } = string.Empty;

    public List<Familia> Familias { get; set; } = [];
}
