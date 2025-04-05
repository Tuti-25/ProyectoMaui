namespace AppMaui.Paginas;

public partial class CrearCaso : ContentPage
{
	public CrearCaso()
	{
		InitializeComponent();
	}

    private async void BtnCancelar_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CasosFiltros());
    }
}