using Demo.ApiClient2;
using Demo.ApiClient2.Models.ApiModels;


namespace AppMaui.Paginas;

public partial class IngresarDatos : ContentPage
{
    private readonly DemoApiClientService _apiClient;
    private Usuario _usuario;
    public IngresarDatos(DemoApiClientService apiClient, Usuario usuario)
    {
        InitializeComponent();
        _apiClient = apiClient;
        _usuario = usuario;
    }

    private async void BtnIngresar_Clicked(object sender, EventArgs e)
    {
        if (_usuario is null)
        {

            await _apiClient.SaveUsuario(new Usuario
            {

                NombreUsuario = EntryNombre.Text,
                ApellidoUsuario = EntryApellido.Text,
                TelefonoUsuario = EntryNumTelefono.Text,
                CedulaUsuario = EntryCedula.Text,

            });
        }
        else
        {
            await _apiClient.UpdateUsuario(new Usuario
            {
                NombreUsuario = EntryNombre.Text,
                ApellidoUsuario = EntryApellido.Text,
                TelefonoUsuario = EntryNumTelefono.Text,
                CedulaUsuario = EntryCedula.Text,

            });
        }
        await Navigation.PushAsync(new Casos());

    }
}