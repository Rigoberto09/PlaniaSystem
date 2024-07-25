using SistemaPlania.Client.Servicios.Contrato;
using SistemaPlania.Shared;
using System.Net.Http.Json;

namespace SistemaPlania.Client.Servicios.Implementacion
{
    public class CategoriaService : ICategoriaService
    {
     
        private readonly HttpClient _http;
        public CategoriaService(HttpClient http)
        {
            _http = http;
        }
        public async Task<ResponseDTO<List<CategoriaDTO>>> Lista()
        {
            var result = await _http.GetFromJsonAsync<ResponseDTO<List<CategoriaDTO>>>("api/categoria/Lista");
            return result;
        }
    }
}
