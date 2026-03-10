namespace Abstracciones.Modelos
{
    public class ProductoBase
    {
        public Guid IdSubCategoria { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public string CodigoBarras { get; set; }
    }

    public class ProductoRequest : ProductoBase
    {

    }

    public class ProductoResponse : ProductoBase
    {
        public Guid Id { get; set; }
    }

    public class ProductoDetalle : ProductoResponse
    {
        public bool RevisionValida { get; set; }
        public bool RegistroValido { get; set; }
    }
}