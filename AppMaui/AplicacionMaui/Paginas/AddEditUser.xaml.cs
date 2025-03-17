using Demo.ApiClient2;
using Demo.ApiClient2.Models.ApiModels;

namespace AplicacionMaui.Paginas;

public partial class AddEditUser : ContentPage
{

    private readonly DemoApiClientService _apiClient;
    private Usuario _usuario;
    public AddEditUser(DemoApiClientService apiClient, Usuario usuario)
	{
		InitializeComponent();
        _apiClient = apiClient;
        _usuario = usuario;
    }

    private void LoadUsuarioDetalles()
    {
        if (_usuario is not null)
        {
            txtNombreUsuario.Text = _usuario.NombreUsuario;
            txtApellido.Text = _usuario.ApellidoUsuario;
            txtCorreo.Text = _usuario.CorreoUsuario;
            txtTelefono.Text = _usuario.TelefonoUsuario;
            txtUbicacion.Text = _usuario.UbicacionUsuario;
            txtCedula.Text = _usuario.CedulaUsuario;
            txtContrasena.Text = _usuario.ContrasenaUsuario;
            txtRol.Text = _usuario.IdRol.ToString();

        }
    }

    private void btnGuardar_Clicked(object sender, EventArgs e)
    {

    }

    private void btnCancelar_Clicked(object sender, EventArgs e)
    {

    }
}