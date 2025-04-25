using Demo.ApiClient2;
using Demo.ApiClient2.Models.ApiModels;

namespace AppMaui.Paginas;

public partial class CasosFiltros : ContentPage
{
    private readonly DemoApiClientService _apiClient;

    public CasosFiltros(DemoApiClientService apiClient)
	{
		InitializeComponent();
        _apiClient = apiClient;


    }
    private async void LblRegreso_Tapped(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new Casos(_apiClient));
    }
}