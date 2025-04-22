namespace AppMaui.Paginas;

public partial class Chats : ContentPage
{
	public Chats()
	{
		InitializeComponent();
	}

    private async void ImgBtnCasos_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new LoginOrSignUp());

    }
}