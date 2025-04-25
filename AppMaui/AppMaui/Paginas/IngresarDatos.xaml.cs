using Demo.ApiClient2;
using Demo.ApiClient2.Models.ApiModels;
using System.Text.RegularExpressions;

namespace AppMaui.Paginas;

public partial class IngresarDatos : ContentPage
{
    private readonly DemoApiClientService _apiClient;
    private readonly Usuario _usuario;

    public IngresarDatos(DemoApiClientService apiClient, Usuario usuario)
    {
        InitializeComponent();
        _apiClient = apiClient;
        _usuario = usuario;
    }

    private async void BtnIngresar_Clicked(object sender, EventArgs e)
    {
        _usuario.NombreUsuario = EntryNombre.Text?.Trim();
        _usuario.ApellidoUsuario = EntryApellido.Text?.Trim();
        _usuario.CedulaUsuario = EntryCedula.Text?.Trim();
        _usuario.TelefonoUsuario = EntryNumTelefono.Text?.Trim();
        _usuario.CodigoCasa = EntryNumCasa.Text?.Trim();

        if (string.IsNullOrEmpty(_usuario.NombreUsuario) || string.IsNullOrEmpty(_usuario.ApellidoUsuario) ||
            string.IsNullOrEmpty(_usuario.CedulaUsuario) || string.IsNullOrEmpty(_usuario.TelefonoUsuario) ||
            string.IsNullOrEmpty(_usuario.CodigoCasa))
        {
            await DisplayAlert("Error", "Por favor, complete todos los campos.", "Aceptar");
            return;
        }

        if (_usuario.TelefonoUsuario.Length != 8 || !Regex.IsMatch(_usuario.TelefonoUsuario, @"^\d+$"))
        {
            await DisplayAlert("Error", "El numero de telefono debe tener 8 digitos", "Aceptar");
            return;
        }

        if (_usuario.CodigoCasa.Length > 5)
        {
            await DisplayAlert("Error", "El codigo de la casa debe tener un maximo de 5 caracteres", "Aceptar");
            return;
        }


        var usuarioConCedulaExistente = await _apiClient.BuscarUsuarioPorCedula(_usuario.CedulaUsuario);

        if (usuarioConCedulaExistente != null && usuarioConCedulaExistente.IdUsuario != _usuario.IdUsuario)
        {
            await DisplayAlert("Error", "Ya existe un usuario con esta cédula", "Aceptar");
            return;
        }


        var usuarioConMismoCorreoYNombre = await _apiClient.BuscarUsuarioPorCorreo(_usuario.CorreoUsuario);
        if (usuarioConMismoCorreoYNombre != null &&
            usuarioConMismoCorreoYNombre.NombreUsuario == _usuario.NombreUsuario &&
            usuarioConMismoCorreoYNombre.ApellidoUsuario == _usuario.ApellidoUsuario)
        {
            await DisplayAlert("Error", "Ya existe un usuario con este nombre, apellido y correo", "Aceptar");
            return;
        }

        await _apiClient.UpdateUsuario(_usuario);

        await DisplayAlert($"Bienvenido {_usuario.NombreUsuario}.", "Ya puedes quejarte con libertad", "Aceptar");
        await Navigation.PushModalAsync(new Casos(_apiClient));
    }
}
