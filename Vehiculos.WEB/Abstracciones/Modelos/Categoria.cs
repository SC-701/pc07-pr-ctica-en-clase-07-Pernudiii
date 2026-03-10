using System;
using System.Collections.Generic;

namespace Abstracciones.Modelos
{
    // Equivalente a Marca de vehiculo jaja, pero para Categoría de Producto
    public class Categoria
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
    }

    // lo mismo aqui es modelo
    public class SubCategoria
    {
        public Guid Id { get; set; }
        public Guid IdCategoria { get; set; }  
        public string Nombre { get; set; }
    }
}