using Abstracciones.Interfaces.DA;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Interfaces.Reglas;
using Abstracciones.Modelos;

namespace Flujo
{
    public class ProductoFlujo : IProductoFlujo
    {
        private readonly IProductoDA _productoDA;
        private readonly IProductoRegistroReglas _registroReglas;
        private readonly IProductoRevisionReglas _revisionReglas;

        public ProductoFlujo(
            IProductoDA productoDA,
            IProductoRevisionReglas revisionReglas,
            IProductoRegistroReglas registroReglas)
        {
            _productoDA = productoDA;
            _revisionReglas = revisionReglas;
            _registroReglas = registroReglas;
        }

        public async Task<Guid> Agregar(ProductoRequest producto)
        {
            return await _productoDA.Agregar(producto);
        }

        public async Task<Guid> Editar(Guid Id, ProductoRequest producto)
        {
            return await _productoDA.Editar(Id, producto);
        }

        public async Task<Guid> Eliminar(Guid Id)
        {
            return await _productoDA.Eliminar(Id);
        }

        public async Task<IEnumerable<ProductoResponse>> Obtener()
        {
            // Para listas, no necesitamos detalle
            return await _productoDA.Obtener();
        }

        public async Task<ProductoDetalle> Obtener(Guid Id)
        {
            // Obtener producto del DA como ProductoDetalle
            ProductoDetalle producto = await _productoDA.Obtener(Id) as ProductoDetalle;

            if (producto == null)
                throw new Exception("El producto no existe");

            // Validaciones
            producto.RegistroValido =
                await _registroReglas.ProductoEstaRegistrado(producto.CodigoBarras);

            producto.RevisionValida =
                await _revisionReglas.ProductoEsValido(producto.CodigoBarras);

            return producto;
        }
    }
}