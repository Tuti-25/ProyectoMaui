using Demo.ApiClient2.Models;
using Demo.ApiClient2.Models.ApiModels;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Text;

namespace Demo.ApiClient2
{
    public class DemoApiClientService
    {
        private readonly HttpClient _httpClient;

        public DemoApiClientService(ApiClientOptions apiClientOptions)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new System.Uri(apiClientOptions.ApiBaseAddress);
        }

        public async Task<List<Usuario>?> GetUsuarios()
        {
            return await _httpClient.GetFromJsonAsync<List<Usuario>?>("/api/User");
        }



        public async Task<Usuario?> GetById(int idusuario)
        {
            return await _httpClient.GetFromJsonAsync<Usuario?>($"/api/User/{idusuario}");
        }



        public async Task SaveUsuario(Usuario usuario)
        {
            await _httpClient.PostAsJsonAsync("/api/User",usuario);
        }



        public async Task UpdateUsuario(Usuario usuario)
        {
            await _httpClient.PutAsJsonAsync("/api/User", usuario.IdUsuario);
        }

        public async Task DeleteUsuario(int idusuario)
        {
            await _httpClient.DeleteAsync($"/api/User/{idusuario}");
        }
    }
}
