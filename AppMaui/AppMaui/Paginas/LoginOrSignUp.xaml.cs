using Demo.ApiClient2;
using Demo.ApiClient2.Models.ApiModels;

namespace AppMaui.Paginas;

public partial class LoginOrSignUp : ContentPage
{
    private readonly DemoApiClientService _apiClient;


    public LoginOrSignUp(DemoApiClientService apiClient)
    {
        InitializeComponent();
        _apiClient = apiClient;
    }


    private async void BtnLogIn_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new Login(_apiClient));
    }
    private async void BtnSignUp_Clicked(object sender, EventArgs e)
    {
        var usuarioNuevo = new Usuario();
        await Navigation.PushModalAsync(new SignUp(_apiClient, usuarioNuevo));
    }

}