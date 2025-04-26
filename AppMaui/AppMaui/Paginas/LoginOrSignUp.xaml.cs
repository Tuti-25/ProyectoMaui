using AppMaui.Popups;
using CommunityToolkit.Maui.Views;
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

    private async void BtnLogin_Clicked_1(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new Login(_apiClient));
    }

    private async void BtnSignUp_Clicked_1(object sender, EventArgs e)
    {
        var usuarioNuevo = new Usuario();
        await Navigation.PushModalAsync(new SignUp(_apiClient, usuarioNuevo));
    }

    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        var result = await this.ShowPopupAsync(new AgentePopUp());

        if (result is null)
        {
            await DisplayAlert("Error", "No se ingresaron datos del agente", "OK");
            return;
        }

        dynamic agente = result;

        if (!int.TryParse(agente.IdAgente.ToString(), out int idAgente))
        {
            await DisplayAlert("Error", "Ingrese un ID valido", "OK");
            return;
        }

        string cedulaAgente = agente.CedulaAgente;

        var resultado = await _apiClient.GetAgenteByIdYCedula(idAgente, cedulaAgente);

        if (resultado != null)
        {
            await DisplayAlert("Bienvenido", $"¡Bienvenido {resultado.NombreAgente}!", "Continuar");
            await Navigation.PushModalAsync(new Menu());
        }
        else
        {
            await DisplayAlert("Error", "ID o cedula de incorrectos", "OK");
        }
    }
}
