namespace AppMaui.Paginas;

public partial class CasosFiltros : ContentPage
{
	public CasosFiltros()
	{
		InitializeComponent();

    }
    private async void LblRegreso_Tapped(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new Casos());
    }
}