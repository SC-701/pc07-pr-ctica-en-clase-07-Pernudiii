using Abstracciones.Modelo;
using Abstracciones.Modelo.Abstracciones.Modelo;

namespace Abstracciones.Interfaces.DA
{
    public interface IProductoDA
    {
        Task<IEnumerable<ProductoResponse>> Obtener();
        Task<ProductoResponse> Obtener(Guid Id);
        Task<Guid> Agregar(ProductoRequest producto);
        Task<Guid> Editar(Guid Id, ProductoRequest producto);
        Task<Guid> Eliminar(Guid Id);
    }
}
