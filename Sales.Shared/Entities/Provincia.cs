using System.ComponentModel.DataAnnotations;

namespace Sales.Shared.Entities
{
    public class Provincia
    {
        public int Id { get; set; }

        [Display(Name = "Provincia")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener más de {1} carácteres")]
        public string? Nombre { get; set; }
    }
}
