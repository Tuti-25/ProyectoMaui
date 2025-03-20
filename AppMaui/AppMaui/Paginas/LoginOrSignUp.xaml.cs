namespace AppMaui.Paginas;

public partial class LoginOrSignUp : ContentPage
{
	public LoginOrSignUp()
	{
		InitializeComponent();
	}

    private async void BtnLogIn_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Login());
    }
    private async void BtnSignUp_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new SignUp());
    }
}