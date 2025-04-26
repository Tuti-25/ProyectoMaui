using System;
using System.Collections.Generic;
using Microsoft.Maui.Controls;

namespace MenuView.Views
{
    public partial class MainPage : ContentPage
    {
        private List<string> consejos;
        private int indiceConsejoActual;

        public MainPage()
        {
            InitializeComponent();
            //Aquí está para cuando ya esté enlazado con la base de datos para que se muestren los mensajes de bienvenida y muestre el usuario que inicio
            // Cargar los datos del usuario (comentado mientras no se integra base de datos)
            //UsuarioService.UsuarioActual = UsuarioService.ObtenerUsuarioPorId(1);

            //if (UsuarioService.UsuarioActual != null)
            //{
            //    lblBienvenida.Text = $"Hola, {UsuarioService.UsuarioActual.Nombre}, bienvenido/a a nuestra aplicación de reportes";
            //}
            //else
            //{
            //    lblBienvenida.Text = "Hola, usuario desconocido";
            //}

            lblBienvenida.Text = "Hola, bienvenido/a a nuestra aplicación de reportes";

            consejos = new List<string>
            {
                "Recuerda siempre indicar la zona del reporte para así identificarla con más facilidad",
                "Recomendamos dejar una foto para entender la gravedad del asunto",
                "Los reportes pueden demorar máximo una semana en ser resueltos",
                "En caso de haber algún problema más específico, está el apartado de Chat"
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

        //Está es la parte de los "enlaces". En teoría está listo para que cuando esté todo junto si dirija a la pestaña
        //correspondiente. Por lo pronto, nada más sale ese mensaje ya que tuve complicaciones con el proyecto y la base.
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

                await DisplayAlert("Acción", "Aquí se mostrará la pantalla de casos.", "OK");
            }
            else if (sender == btnChat)
            {
                btnChat.Source = "chatblue.png";
                lblChat.TextColor = Color.FromArgb("#5a5a5a");

                await DisplayAlert("Acción", "Aquí se mostrará la pantalla de chat.", "OK");
            }
            else if (sender == btnNotificacion)
            {
                btnNotificacion.Source = "notificacionblue.png";
                lblNotificacion.TextColor = Color.FromArgb("#5a5a5a");

                await DisplayAlert("Acción", "Aquí se mostrará la pantalla de notificaciones.", "OK");
            }
        }
    }
}
