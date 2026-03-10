using Abstracciones.Interfaces.Reglas;
using Abstracciones.Interfaces.Servicios;

namespace Reglas
{
    public class ProductoRegistroReglas : IProductoRegistroReglas
    {
        private readonly IRegistroProductoServicio _registroServicio;
        private readonly IConfiguracion _configuracion;

        public ProductoRegistroReglas(
            IRegistroProductoServicio registroServicio,
            IConfiguracion configuracion)
        {
            _registroServicio = registroServicio;
            _configuracion = configuracion;
        }

        public async Task<bool> ProductoEstaRegistrado(string codigoBarras)
        {
            var resultadoRegistro = await _registroServicio.Obtener(codigoBarras);

            return (resultadoRegistro != null);
        }
    }
}