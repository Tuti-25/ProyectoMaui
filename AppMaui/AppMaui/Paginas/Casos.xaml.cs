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
}