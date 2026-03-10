using Abstracciones.Modelos.Servicios.Registro;

namespace Abstracciones.Interfaces.Servicios
{
    public interface IRegistroProductoServicio
    {
        Task<Producto> Obtener(string codigoBarras);
    }
}
