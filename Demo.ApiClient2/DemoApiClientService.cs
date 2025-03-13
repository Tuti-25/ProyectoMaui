using Demo.ApiClient2.Models;
using Demo.ApiClient2.Models.ApiModels;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

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
            return await _httpClient.GetFromJsonAsync<List<Usuario>>("api/usuarios");
        }

        public async Task<Usuario?> GetById(int idusuario)
        {
            return await _httpClient.GetFromJsonAsync<Usuario>($"api/usuarios/{idusuario}");
        }

        public async Task SaveUsuario(Usuario usuario)
        {
            await _httpClient.PostAsJsonAsync("api/usuarios", usuario);
        }

        public async Task UpdateUsuario(Usuario usuario)
        {
            await _httpClient.PutAsJsonAsync("api/usuarios", usuario);
        }

        public async Task DeleteUsuario(int idusuario)
        {
            await _httpClient.DeleteAsync($"api/usuarios/{idusuario}");
        }
    }
}
