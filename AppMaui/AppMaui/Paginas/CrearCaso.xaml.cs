using AppMaui.Popups;
using CommunityToolkit.Maui.Views;
using Demo.ApiClient2;
using Demo.ApiClient2.Models.ApiModels;

namespace AppMaui.Paginas;

public partial class CrearCaso : ContentPage
{
    private readonly DemoApiClientService _apiClient;
    private int _idSeveridadSeleccionada = 0;
    private readonly Usuario _usuarioLogueado;

    public CrearCaso(DemoApiClientService apiClient)
    {
        InitializeComponent();
        _apiClient = apiClient;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        var usuario = UsuarioActual.UsuarioLogueado;

        if (usuario != null)
        {
            LblNombreCreadorCaso.Text = $"{usuario.NombreUsuario} {usuario.ApellidoUsuario}";
        }
    }

    private async void BtnCancelar_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Casos(_apiClient));
    }

    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        var severidades = await _apiClient.GetSeveridades();
        if (severidades == null || severidades.Count == 0)
        {
            await DisplayAlert("Error", "No se encontraron severidades", "OK");
            return;
        }

        var popup = new SeveridadesPopup(severidades);
        var resultado = await this.ShowPopupAsync(popup);

        if (resultado is Severidad severidadSeleccionada)
        {
            _idSeveridadSeleccionada = severidadSeleccionada.IdSeveridad;
            LblSeveridad.Text = severidadSeleccionada.DescripcionSeveridad;

            string imagen = severidadSeleccionada.TipoSeveridad switch
            {
                1 => "uno.png",
                2 => "dos.png",
                3 => "tres.png",
                4 => "cuatro.png"
            };

            BtnImgSeveridad.Source = imagen;
        }
    }


    private void ImageButton_Clicked(object sender, EventArgs e)
    {

    }
}
