namespace AppMaui.Paginas;

public partial class ConfirmEmail : ContentPage
{
	public ConfirmEmail()
	{
		InitializeComponent();
	}

    private void BtnVerificarCodigo_Clicked(object sender, EventArgs e)
    {
        // Obtener entradas del usuario
        string codigoIngresado = entry1.Text + entry2.Text + entry3.Text + entry4.Text + entry5.Text + entry6.Text;

        string codigoCorrecto = Preferences.Get("codigo_verificacion", string.Empty);

        if (codigoIngresado == codigoCorrecto)
        {
            DisplayAlert("Éxito", "Código verificado correctamente", "OK");
            // Continuar con registro, login o lo que necesites
        }
        else
        {
            DisplayAlert("Error", "El código ingresado es incorrecto", "Intentar de nuevo");
        }
    }

}