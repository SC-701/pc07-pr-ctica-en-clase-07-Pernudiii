using Abstracciones.Interfaces.Reglas;
using Abstracciones.Interfaces.Servicios;
using Abstracciones.Modelos.Servicios.Registro;
using System.Text.Json;

namespace Servicios
{
    public class RegistroProductoServicio : IRegistroProductoServicio
    {
        private readonly IConfiguracion _configuracion;
        private readonly IHttpClientFactory _httpClient;

        public RegistroProductoServicio(IConfiguracion configuracion, IHttpClientFactory httpClient)
        {
            _configuracion = configuracion;
            _httpClient = httpClient;
        }

        public async Task<Producto> Obtener(string codigoBarras)
        {
            var endPoint = _configuracion.ObtenerMetodo("ApiEndPointsRegistroProducto", "ObtenerRegistroProducto");

            var servicioRegistro = _httpClient.CreateClient("ServicioRegistroProducto");

            var respuesta = await servicioRegistro.GetAsync(string.Format(endPoint, codigoBarras));

            respuesta.EnsureSuccessStatusCode();

            var resultado = await respuesta.Content.ReadAsStringAsync();

            var opciones = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            var resultadoDeserializado = JsonSerializer.Deserialize<List<Producto>>(resultado, opciones);

            return resultadoDeserializado.FirstOrDefault();
        }
    }
}