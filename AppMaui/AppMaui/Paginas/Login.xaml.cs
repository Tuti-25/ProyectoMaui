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
        await Navigation.PushAsync(new Casos(_apiClient));

    }
}
