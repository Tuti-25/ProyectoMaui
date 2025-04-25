using Demo.ApiClient2;
using Demo.ApiClient2.Models;
using Demo.ApiClient2.Models.ApiModels;

namespace AppMaui.Paginas;

public partial class Login : ContentPage
{

    private readonly DemoApiClientService _apiClient;
    public Login(DemoApiClientService apiClient)
    {
        InitializeComponent();
        _apiClient = apiClient;
    }

    private async void BtnLogin_Clicked(object sender, EventArgs e)
    {
        string correo = EntryMail.Text?.Trim();
        string contrasena = EntryContrasena.Text?.Trim();

        if (string.IsNullOrWhiteSpace(correo) || string.IsNullOrWhiteSpace(contrasena))
        {
            await DisplayAlert("Error", "Por favor ingrese el correo y la contrasena", "Aceptar");
            return;
        }

        var usuario = await _apiClient.ValidarCredenciales(correo, contrasena);

        if (usuario != null)
        {
            UsuarioActual.UsuarioLogueado = usuario;

            await DisplayAlert("Bienvenido", $"Hola {usuario.NombreUsuario}", "Continuar");

            await Navigation.PushModalAsync(new Casos(_apiClient));
        }
        else
        {
            await DisplayAlert("Error", "Correo o contrasena incorrecta", "Intentar de nuevo");
        }
    }


}
