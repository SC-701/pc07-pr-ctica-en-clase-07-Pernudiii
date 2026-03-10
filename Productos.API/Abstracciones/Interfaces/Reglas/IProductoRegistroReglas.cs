namespace Abstracciones.Interfaces.Reglas
{
    public interface IProductoRegistroReglas
    {
        Task<bool> ProductoEstaRegistrado(string codigoBarras);
    }
}