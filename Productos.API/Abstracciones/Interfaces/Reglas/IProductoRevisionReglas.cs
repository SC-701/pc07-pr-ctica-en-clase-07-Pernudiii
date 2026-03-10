namespace Abstracciones.Interfaces.Reglas
{
    public interface IProductoRevisionReglas
    {
        Task<bool> ProductoEsValido(string codigoBarras);
    }
}