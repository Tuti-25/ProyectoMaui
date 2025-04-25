using Demo.ApiClient2;

namespace AppMaui.Paginas;

public partial class CrearCaso : ContentPage
{
    private readonly DemoApiClientService _apiClient;
    public CrearCaso(DemoApiClientService apiClient)
	{
		InitializeComponent();
        _apiClient = apiClient;
    }

    private async void BtnCancelar_Clicked(object sender, EventArgs e)
    {

        await Navigation.PushAsync(new Casos(_apiClient));
    }
}