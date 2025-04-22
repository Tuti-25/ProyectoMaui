namespace AppMaui.Paginas;

public partial class SignUp : ContentPage
{
	public SignUp()
	{
		InitializeComponent();

	}

    private async void BtnSignUp2_Clicked(object sender, EventArgs e)
    {
		await Navigation.PushAsync(new IngresarDatos());
    }
}