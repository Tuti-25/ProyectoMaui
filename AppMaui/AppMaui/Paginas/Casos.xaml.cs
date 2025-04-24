namespace AppMaui.Paginas;

public partial class Casos : ContentPage
{
	public Casos()
	{
		InitializeComponent();


    }
    private async void TapFiltros_Tapped(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new CasosFiltros());
    }

    private async void BtnCrearCaso_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CrearCaso());

    }

    private async void BtnPerfil_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new LoginOrSignUp());

    }

    private async void BtnImgChat_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Chats());

    }
    private void BtnConfiguracion_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Configuracion());
    }


}