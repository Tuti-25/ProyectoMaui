using AppMaui.Popups;
using CommunityToolkit.Maui.Views;
using Demo.ApiClient2;
using Demo.ApiClient2.Models.ApiModels;
using System.Diagnostics;

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

    private async void BtnCancelar_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new Casos(_apiClient));
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

            BtnImgSeveridad.Source = severidadSeleccionada.TipoSeveridad switch
            {
                1 => "uno.png",
                2 => "dos.png",
                3 => "tres.png",
                4 => "cuatro.png",
                _ => "default.png"
            };
        }
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        var usuario = UsuarioActual.UsuarioLogueado;

        if (usuario != null)
        {
            LblNombreCreadorCaso.Text = $"{usuario.NombreUsuario} {usuario.ApellidoUsuario}";
        }

        var roles = await _apiClient.GetTiposDeRolesAsync();
        if (roles != null && roles.Any())
        {
            PickerRoles.ItemsSource = roles;
        }
        else
        {
            Debug.WriteLine("No se encontraron roles o la lista está vacía.");
        }
    }

    private async void BtnCrear_Clicked(object sender, EventArgs e)
    {
        if (_idSeveridadSeleccionada == 0)
        {
            await DisplayAlert("Error", "Debe seleccionar una severidad para el caso", "OK");
            return;
        }

        var rolSeleccionado = PickerRoles.SelectedItem as Rol;
        if (rolSeleccionado == null)
        {
            await DisplayAlert("Error", "Debe seleccionar un rol", "OK");
            return;
        }

        var usuario = UsuarioActual.UsuarioLogueado;
        if (usuario == null)
        {
            await DisplayAlert("Error", "No se encontró el usuario logueado", "OK");
            return;
        }

        if (string.IsNullOrWhiteSpace(EditorDescripcion.Text))
        {
            await DisplayAlert("Error", "Debe ingresar una descripción para el caso", "OK");
            return;
        }

        var caso = new Caso
        {
            DescripcionCaso = EditorDescripcion.Text,
            IdUsuario = usuario.IdUsuario,
            IdSeveridad = _idSeveridadSeleccionada
        };

        var (exito, mensaje) = await _apiClient.CrearCasoAsync(caso);

        if (exito)
        {
            await DisplayAlert("Éxito", "El caso se creó correctamente.", "OK");
            await Navigation.PushModalAsync(new Casos(_apiClient));
        }
        else
        {
            await DisplayAlert("Error", $"Error al crear el caso: {mensaje}", "OK");
        }
    }

}
