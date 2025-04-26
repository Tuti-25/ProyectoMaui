using Demo.ApiClient2;
using Demo.ApiClient2.Models.ApiModels;

namespace AppMaui.Paginas;

public partial class Casos : ContentPage
{
    private readonly DemoApiClientService _apiClient;
    public Casos(DemoApiClientService apiClient)
    {
        InitializeComponent();
        _apiClient = apiClient;
    }
    private async void TapFiltros_Tapped(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new CasosFiltros(_apiClient));
    }

    private async void BtnCrearCaso_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new CrearCaso(_apiClient));

    }

    private async void BtnPerfil_Clicked(object sender, EventArgs e)
    {
        var usuarioNuevo = new Usuario();
        await Navigation.PushModalAsync(new LoginOrSignUp(_apiClient));

    }

    private async void BtnImgChat_Clicked(object sender, EventArgs e)
    {
        var usuarioNuevo = new Usuario();
        await Navigation.PushAsync(new LoginOrSignUp(_apiClient));

    }
    private void BtnConfiguracion_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Configuracion());
    }


}