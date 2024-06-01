using System.ComponentModel.DataAnnotations;

namespace RestaurantApp.Domain.Models;

public class Familia
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "O campo Nome é obrigatório.")]
    [StringLength(60, ErrorMessage = "O campo Nome deve ter no máximo 60 caracteres.")]
    [RegularExpression("^[a-zA-Z0-9 ]+$", ErrorMessage = "O campo Nome deve conter apenas letras, números e espaços.")]
    [Display(Name = "Nome da Família")]
    public string Nome { get; set; } = string.Empty;

    // Propriedade de navegação para o Grupo
    [Display(Name = "Grupo")]
    public required Grupo Grupo { get; set; }

    // Chave estrangeira para o Grupo
    [Display(Name = "Código do Grupo")]
    public int GrupoId { get; set; }
}
