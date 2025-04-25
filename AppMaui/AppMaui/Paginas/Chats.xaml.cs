using Demo.ApiClient2;
using Demo.ApiClient2.Models.ApiModels;

namespace AppMaui.Paginas;

public partial class Chats : ContentPage
{
    private readonly DemoApiClientService _apiClient;
    public Chats(DemoApiClientService apiClient)
	{
		InitializeComponent();
        _apiClient = apiClient;

    }

    private async void ImgBtnCasos_Clicked(object sender, EventArgs e)
    {
        var usuarioNuevo = new Usuario();
        await Navigation.PushAsync(new SignUp(_apiClient, usuarioNuevo));


    }
}