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
using System.Diagnostics;

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
        //AGENTEEEEES
        public async Task<Agente?> GetAgenteByIdYCedula(int idAgente, string cedulaAgente)
        {
            try
            {
                var response = await _httpClient.GetAsync($"/api/Agent/validate/{idAgente}/{cedulaAgente}");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<Agente>();
                }

                Console.WriteLine($"Error al validar agente: {response.StatusCode}");
                return null;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Request failed: {ex.Message}");
                throw;
            }
        }
        public async Task<List<Agente>> GetAgentesAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("http://192.168.100.92:5151/api/Agent");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var agentes = JsonSerializer.Deserialize<List<Agente>>(json, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    }) ?? new List<Agente>();

                    return agentes;
                }

                Console.WriteLine($"Error al obtener agentes: {response.StatusCode}");
                return new List<Agente>();
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Request failed: {ex.Message}");
                throw;
            }
        }

        //ROLEEEEEES

        public async Task<List<Rol>> GetTiposDeRolesAsync()
        {
            var response = await _httpClient.GetAsync("/api/rolecontroller1");

            if (response.IsSuccessStatusCode)
            {
                var roles = await response.Content.ReadFromJsonAsync<List<Rol>>();
                if (roles != null && roles.Count > 0)
                {
                    foreach (var rol in roles)
                    {
                        Debug.WriteLine($"Rol: {rol.TipoRol}");
                    }
                    return roles;
                }
                else
                {
                    Debug.WriteLine("No se encontraron roles.");
                }
            }
            else
            {
                Debug.WriteLine($"Error en la respuesta: {response.StatusCode}");
            }

            return new List<Rol>();
        }




    }
}
