using Abstracciones.Modelos.Servicios.Revision;

namespace Abstracciones.Interfaces.Servicios
{
    public interface IRevisionProductoServicio
    {
        Task<Revision> Obtener(string codigoBarras);
    }
}