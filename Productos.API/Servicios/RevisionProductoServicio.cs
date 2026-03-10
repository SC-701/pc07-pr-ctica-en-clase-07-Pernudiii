using Abstracciones.Interfaces.Reglas;
using Abstracciones.Interfaces.Servicios;
using Abstracciones.Modelos.Servicios.Revision;
using System.Text.Json;

namespace Servicios
{
    public class RevisionProductoServicio : IRevisionProductoServicio
    {
        private readonly IConfiguracion _configuracion;
        private readonly IHttpClientFactory _httpClient;

        public RevisionProductoServicio(IConfiguracion configuracion, IHttpClientFactory httpClient)
        {
            _configuracion = configuracion;
            _httpClient = httpClient;
        }

        public async Task<Revision> Obtener(string codigoBarras)
        {
            var endPoint = _configuracion.ObtenerMetodo("ApiEndPointsRevisionProducto", "ObtenerRevisionProducto");

            var servicioRevision = _httpClient.CreateClient("ServicioRevisionProducto");

            var respuesta = await servicioRevision.GetAsync(string.Format(endPoint, codigoBarras));

            respuesta.EnsureSuccessStatusCode();

            var resultado = await respuesta.Content.ReadAsStringAsync();

            var opciones = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            var resultadoDeserializado = JsonSerializer.Deserialize<List<Revision>>(resultado, opciones);

            return resultadoDeserializado.FirstOrDefault();
        }
    }
}