using System;
using System.ComponentModel.DataAnnotations;

namespace Abstracciones.Modelo
{
    using System;
    using System.ComponentModel.DataAnnotations;

    namespace Abstracciones.Modelo
    {
        public class ProductoBase
        {
            // Main information
            [Required(ErrorMessage = "Name is required.")]
            [StringLength(15, MinimumLength = 2,
                ErrorMessage = "Name must be between 2 and 15 characters.")]
            public string Nombre { get; set; } = string.Empty;

            [Required(ErrorMessage = "Description is required.")]
            [StringLength(40, MinimumLength = 4,
                ErrorMessage = "Description must be between 4 and 40 characters.")]
            public string Descripcion { get; set; } = string.Empty;

            // Commercial information
            [Required(ErrorMessage = "Price is required.")]
            [Range(0.01, double.MaxValue,
                ErrorMessage = "Price must be greater than zero.")]
            public decimal Precio { get; set; }

            [Required(ErrorMessage = "Stock is required.")]
            [Range(0, int.MaxValue,
                ErrorMessage = "Stock cannot be negative.")]
            public int Stock { get; set; }

            // Identification
            [Required(ErrorMessage = "Barcode is required.")]
            [StringLength(13, MinimumLength = 8,
                ErrorMessage = "Barcode must be between 8 and 13 characters.")]
            public string CodigoBarras { get; set; } = string.Empty;
        }

        // Model used for create or update operations
        public class ProductoRequest : ProductoBase
        {
            [Required(ErrorMessage = "Subcategory is required.")]
            public Guid IdSubCategoria { get; set; }
        }

        // Model returned by the API
        public class ProductoResponse : ProductoBase
        {
            public Guid Id { get; set; }
            public string SubCategoria { get; set; } = string.Empty;
            public string Categoria { get; set; } = string.Empty;
        }
    }
}
