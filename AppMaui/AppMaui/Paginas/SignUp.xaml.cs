using Demo.ApiClient2;
using Demo.ApiClient2.Models.ApiModels;
using System.Text.RegularExpressions;
using BCrypt.Net;

namespace AppMaui.Paginas;

public partial class SignUp : ContentPage
{
    private readonly DemoApiClientService _apiClient;
    private Usuario _usuario;

    public SignUp(DemoApiClientService apiClient, Usuario usuario)
    {
        InitializeComponent();
        _apiClient = apiClient;
        _usuario = usuario;
    }

    private async void BtnSignUp2_Clicked(object sender, EventArgs e)
    {
        string correo = EntryMail.Text?.Trim();
        string contrasena = EntryContrasena.Text;

        if (string.IsNullOrEmpty(correo) || string.IsNullOrEmpty(contrasena))
        {
            await DisplayAlert("Error", "No ha ingresado un valor en el correo o contrasena", "Aceptar");
            return;
        }

        if (!EsCorreoValido(correo))
        {
            await DisplayAlert("Correo inválido", "Por favor ingrese un correo valido", "Aceptar");
            return;
        }

        var usuarioExistente = await _apiClient.BuscarUsuarioPorCorreo(correo);

        if (usuarioExistente != null)
        {
            await DisplayAlert("Correo ya registrado", "Por favor ingrese otro correo", "Aceptar");
            return;
        }


        var nuevoUsuario = new Usuario
        {
            CorreoUsuario = correo,
            ContrasenaUsuario = contrasena
        };


        await _apiClient.SaveUsuario(nuevoUsuario);

        var usuarioCreado = await _apiClient.BuscarUsuarioPorCorreo(nuevoUsuario.CorreoUsuario);

        if (usuarioCreado == null)
        {
            await DisplayAlert("Error", "No se pudo obtener el usuario recien creado", "Aceptar");
            return;
        }

        await Navigation.PushModalAsync(new IngresarDatos(_apiClient, usuarioCreado));
    }

    private bool EsCorreoValido(string correo)
    {
        return Regex.IsMatch(correo, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
    }

    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        await Navigation.PushModalAsync(new LoginOrSignUp(_apiClient));

    }
}
