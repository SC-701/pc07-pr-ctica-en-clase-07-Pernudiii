using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Abstracciones.Modelos
{
    public class ProductoBase
    {
        [Required(ErrorMessage = "El nombre del producto es requerido")]
        [StringLength(100, ErrorMessage = "El nombre debe tener entre 3 y 100 caracteres", MinimumLength = 3)]
        public string Nombre { get; set; }

        [StringLength(500, ErrorMessage = "La descripción debe tener máximo 500 caracteres")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El precio del producto es requerido")]
        public decimal Precio { get; set; }

        [Required(ErrorMessage = "El stock es requerido")]
        [Range(0, int.MaxValue, ErrorMessage = "El stock debe ser un número positivo")]
        public int Stock { get; set; }

        [Required(ErrorMessage = "El código de barras es requerido")]
        [StringLength(50)]
        public string CodigoBarras { get; set; }

        [Required(ErrorMessage = "La subcategoría es requerida")]
        public Guid IdSubCategoria { get; set; }
    }

    public class ProductoRequest : ProductoBase
    {
       
    }

    public class ProductoResponse : ProductoBase
    {
        public Guid Id { get; set; }
        public string? SubCategoria { get; set; }
        public string? Categoria { get; set; }
    }

    public class ProductoDetalle : ProductoResponse
    {
        public bool RevisionValida { get; set; }
        public bool RegistroValido { get; set; }
    }
}