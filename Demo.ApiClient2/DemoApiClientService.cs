using Demo.ApiClient2.Models;
using Demo.ApiClient2.Models.ApiModels;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Text;
using System;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using BCrypt.Net;

namespace Demo.ApiClient2
{
    public class DemoApiClientService
    {
        private readonly HttpClient _httpClient;

        public DemoApiClientService(ApiClientOptions apiClientOptions)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(apiClientOptions.ApiBaseAddress);
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

        // CASOOOOOS


        public async Task<List<Caso>?> GetCasos()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<Caso>?>("/api/Casos");
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Request failed: {ex.Message}");
                throw;
            }
        }

        public async Task SaveCaso(Caso caso)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("/api/Casos", caso);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Caso guardado correctamente");
                }
                else
                {
                    Console.WriteLine($"Error al guardar el caso: {response.StatusCode}");
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Request failed: {ex.Message}");
                throw;
            }
        }

        public async Task<Usuario?> ValidarCredenciales(string correo, string contrasena)
        {
            var loginData = new { Correo = correo, Contrasena = contrasena };

            var response = await _httpClient.PostAsJsonAsync("api/User/login", loginData);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Usuario>();
            }

            return null;
        }



        // SEVERDIDAAAAA
        public async Task<List<Severidad>?> GetSeveridades()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<Severidad>?>("/api/Severity");
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Request failed: {ex.Message}");
                throw;
            }
        }
    }
}
