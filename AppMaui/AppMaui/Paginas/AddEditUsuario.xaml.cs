using Demo.ApiClient2;
using Demo.ApiClient2.Models.ApiModels;
using Microsoft.Maui.Graphics.Text;

namespace AppMaui.Paginas;

public partial class AddEditUsuario : ContentPage
{
    private readonly DemoApiClientService _apiClient;
    private Usuario _usuario;
	public AddEditUsuario(DemoApiClientService apiClient, Usuario usuario)
	{
		InitializeComponent();
        _apiClient = apiClient;
        _usuario = usuario;
    }

    private void LoadUsuarioDetails()
    {
        if (_usuario is not null)
        {
        
            txtNombreUsuario.Text = _usuario.NombreUsuario;
            txtApellidoUsuario.Text = _usuario.ApellidoUsuario;
            txtCorreoUsuario.Text = _usuario.CorreoUsuario;
            txtTelefonoUsuario.Text = _usuario.TelefonoUsuario;
            txtUbicacionUsuario.Text = _usuario.UbicacionUsuario;
            txtCedulaUsuario.Text = _usuario.CedulaUsuario;
            txtContrasenaUsuario.Text = _usuario.ContrasenaUsuario;
            
        }
    }

    private async void btnCancelar_Clicked(object sender, EventArgs e) {
        await Navigation.PopModalAsync();

    }

    private async void btnGuardar_Clicked(object sender, EventArgs e)
    {
        if (_usuario is null)
        {

            await _apiClient.SaveUsuario(new Usuario
            {
                IdUsuario = int.Parse(txtIdUsuario.Text),

                NombreUsuario = txtNombreUsuario.Text,
                ApellidoUsuario = txtApellidoUsuario.Text,
                CorreoUsuario = txtCorreoUsuario.Text,
                TelefonoUsuario = txtTelefonoUsuario.Text,
                UbicacionUsuario = txtUbicacionUsuario.Text,
                CedulaUsuario = txtCedulaUsuario.Text,
                ContrasenaUsuario = txtContrasenaUsuario.Text,
                IdRol = int.Parse(txtIdRol.Text)

            });
        }
        else
        {
            await _apiClient.UpdateUsuario(new Usuario
            {
                IdUsuario = int.Parse(txtIdUsuario.Text),
                NombreUsuario = txtNombreUsuario.Text,
                ApellidoUsuario = txtApellidoUsuario.Text,
                CorreoUsuario = txtCorreoUsuario.Text,
                TelefonoUsuario = txtTelefonoUsuario.Text,
                UbicacionUsuario = txtUbicacionUsuario.Text,
                CedulaUsuario = txtCedulaUsuario.Text,
                ContrasenaUsuario = txtContrasenaUsuario.Text,
                IdRol = int.Parse(txtIdRol.Text)

            });
        }
        await Navigation.PopModalAsync();

    }
}