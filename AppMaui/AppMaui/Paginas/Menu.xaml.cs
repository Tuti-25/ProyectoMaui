using Demo.ApiClient2;
using Demo.ApiClient2.Models.ApiModels;


namespace AppMaui.Paginas;

public partial class Menu : ContentPage
{
    private List<string> consejos;
    private int indiceConsejoActual;
    private readonly DemoApiClientService _apiClient;

    public Menu()
	{
		InitializeComponent();


        lblBienvenida.Text = "Hola, bienvenido/a a nuestra aplicaci�n de reportes";

        consejos = new List<string>
            {
                "Recuerda siempre indicar la zona del reporte para as� identificarla con m�s facilidad",
                "Recomendamos dejar una foto para entender la gravedad del asunto",
                "Los reportes pueden demorar m�ximo una semana en ser resueltos",
                "En caso de haber alg�n problema m�s espec�fico, est� el apartado de Chat"
            };

        indiceConsejoActual = 0;
        MostrarConsejo();
    }
    private void MostrarConsejo()
    {
        lblConsejo.Text = consejos[indiceConsejoActual];
    }

    private void OnVerMasConsejosClicked(object sender, EventArgs e)
    {
        indiceConsejoActual++;
        if (indiceConsejoActual >= consejos.Count)
        {
            indiceConsejoActual = 0;
        }
        MostrarConsejo();
    }
    private async void OnNavButtonClicked(object sender, EventArgs e)
    {
        btnHome.Source = "home.png";
        btnCasos.Source = "casos.png";
        btnChat.Source = "chat.png";
        btnNotificacion.Source = "notificacion.png";

        lblHome.TextColor = Color.FromArgb("#8f8e94");
        lblCasos.TextColor = Color.FromArgb("#8f8e94");
        lblChat.TextColor = Color.FromArgb("#8f8e94");
        lblNotificacion.TextColor = Color.FromArgb("#8f8e94");

        if (sender == btnHome)
        {
            btnHome.Source = "homeblue.png";
            lblHome.TextColor = Color.FromArgb("#5a5a5a");
        }
        else if (sender == btnCasos)
        {
            btnCasos.Source = "caseblue.png";
            lblCasos.TextColor = Color.FromArgb("#5a5a5a");
            await Navigation.PushModalAsync(new Casos(_apiClient));


        }
        else if (sender == btnChat)
        {
            btnChat.Source = "chatblue.png";
            lblChat.TextColor = Color.FromArgb("#5a5a5a");

            await DisplayAlert("Acci�n", "Aqu� se mostrar� la pantalla de chat.", "OK");
        }
        else if (sender == btnNotificacion)
        {
            btnNotificacion.Source = "notificacionblue.png";
            lblNotificacion.TextColor = Color.FromArgb("#5a5a5a");

            await DisplayAlert("Acci�n", "Aqu� se mostrar� la pantalla de notificaciones.", "OK");
        }
    }

    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        await Navigation.PushModalAsync(new Casos(_apiClient));

    }
}