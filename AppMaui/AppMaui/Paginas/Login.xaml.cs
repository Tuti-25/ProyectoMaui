using Demo.ApiClient2;
using Demo.ApiClient2.Models;
using Demo.ApiClient2.Models.ApiModels;

namespace AppMaui.Paginas;

public partial class Login : ContentPage
{
    private readonly DemoApiClientService _apiClient;

    public Login()
    {
        InitializeComponent();

        var apiClientOptions = new ApiClientOptions
        {
            ApiBaseAddress = "http://localhost:5151"
        };

        _apiClient = new DemoApiClientService(apiClientOptions);
    }

    private async void BtnLogin_Clicked(object sender, EventArgs e)
    {
        string correo = EntryMail.Text;
        string contrasena = EntryContrasena.Text;

        var usuario = new Usuario
        {
            CorreoUsuario = correo,
            ContrasenaUsuario = contrasena
        };

        await Navigation.PushAsync(new IngresarDatos(_apiClient, usuario));
    }
}
