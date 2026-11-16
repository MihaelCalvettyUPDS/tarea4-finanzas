using System;
using System.ComponentModel.DataAnnotations;

namespace finanzas.Models;

public class Categoria
{
    public int CategoriaId { get; set; }

    [Required(ErrorMessage = "El nombre de la categoría es obligatorio.")]
    [MaxLength(100, ErrorMessage = "El nombre de la categoría no puede exceder los 100 caracteres.")]
    public string Nombre { get; set; } 

    [Required(ErrorMessage = "El tipo de categoría es obligatorio.")]
    [MaxLength(20, ErrorMessage = "El tipo de categoría no puede exceder los 20 caracteres.")]
    public string Tipo { get; set; }

    public bool Activo { get; set; } = true;
    public int? CategoriaPadreId { get; set; }
    public Categoria? CategoriaPadre { get; set; }
}
