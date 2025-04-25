using Demo.ApiClient2.Models;
using Demo.ApiClient2.Models.ApiModels;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Text;
using System;
using System.Linq;

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
            try
            {
                return await _httpClient.GetFromJsonAsync<List<Usuario>?>("/api/User");
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Request failed: {ex.Message}");
                throw;
            }
        }
        public async Task<Usuario?> GetById(int idusuario)
        {
            return await _httpClient.GetFromJsonAsync<Usuario?>($"/api/User/{idusuario}");
        }


        public async Task SaveUsuario(Usuario usuario)
        {
            await _httpClient.PostAsJsonAsync("/api/User", usuario);
        }

        public async Task UpdateUsuario(Usuario usuario)
        {
            await _httpClient.PutAsJsonAsync("/api/User", usuario);
        }

        public async Task DeleteUsuario(int idusuario)
        {
            await _httpClient.DeleteAsync($"/api/User/{idusuario}");
        }


        public async Task<Usuario?> BuscarUsuarioPorCorreo(string correo)
        {
            var usuarios = await GetUsuarios();
            return usuarios.FirstOrDefault(u => u.CorreoUsuario == correo);
        }

        public async Task<Usuario?> BuscarUsuarioPorCedula(string cedula)
        {
            var response = await _httpClient.GetAsync($"/api/User/buscar-por-cedula?cedula={cedula}");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Usuario>();
            }

            return null;
        }

    }
}
