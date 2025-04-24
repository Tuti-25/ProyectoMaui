using Demo.ApiClient2;
using Demo.ApiClient2.Models;
using AppMaui;
using Demo.ApiClient2.Models.ApiModels;

namespace AppMaui.Paginas;

public partial class Test : ContentPage
{

    private readonly DemoApiClientService _apiClient;
    private Usuario _usuario;
    public Test(DemoApiClientService apiClient, Usuario usuario)
	{
		InitializeComponent();
        _apiClient = apiClient;
        _usuario = usuario;

    }

    private void LoadUsuarioDetalles()
    {
        if (_usuario != null)
        {
            EntryNombre.Text = _usuario.NombreUsuario;
            EntryApellido.Text = _usuario.ApellidoUsuario;
            EntryCorreo.Text = _usuario.CorreoUsuario;
            EntryCedula.Text = _usuario.CedulaUsuario;
            EntryNumTelefono.Text = _usuario.TelefonoUsuario;
            EntryNumCasa.Text = _usuario.CodigoCasa;
            EntryContrasena.Text = _usuario.ContrasenaUsuario;
        }
    }

    private async void btnCancel_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();

    }

    private async void btnSave_Clicked(object sender, EventArgs e)
    {
        if (_usuario is null)
        {
            await _apiClient.SaveUsuario(new Usuario
            {
                NombreUsuario = EntryNombre.Text,
                ApellidoUsuario = EntryApellido.Text,
                CorreoUsuario = EntryCorreo.Text,
                CedulaUsuario = EntryCedula.Text,
                TelefonoUsuario = EntryNumTelefono.Text,
                CodigoCasa = EntryNumCasa.Text,
                ContrasenaUsuario = EntryContrasena.Text
            });
        }
        else
        { 
            await _apiClient.UpdateUsuario(new Usuario
            {
                IdUsuario = _usuario.IdUsuario,
                NombreUsuario = EntryNombre.Text,
                ApellidoUsuario = EntryApellido.Text,
                CorreoUsuario = EntryCorreo.Text,
                CedulaUsuario = EntryCedula.Text,
                TelefonoUsuario = EntryNumTelefono.Text,
                CodigoCasa = EntryNumCasa.Text,
                ContrasenaUsuario = EntryContrasena.Text
            });

        }
        await Navigation.PopModalAsync();

    }
}