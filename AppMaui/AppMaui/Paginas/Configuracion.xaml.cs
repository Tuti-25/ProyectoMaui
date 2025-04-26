using System;
using Microsoft.Maui.Controls;

namespace AppMaui.Paginas
{
    public partial class Configuracion : ContentPage
    {
        public Configuracion()
        {
            InitializeComponent();

            BtnInvitar.Clicked += BtnInvitar_Clicked;
            BtnNotificaciones.Clicked += BtnNotificaciones_Clicked;
            BtnComentarios.Clicked += BtnComentarios_Clicked;
            BtnCalificar.Clicked += BtnCalificar_Clicked;
            BtnNovedades.Clicked += BtnNovedades_Clicked;
            BtnApps.Clicked += BtnApps_Clicked;
            BtnCompartir.Clicked += BtnCompartir_Clicked;
            BtnAjustes.Clicked += BtnAjustes_Clicked;
        }

        private async void BtnInvitar_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Invitar", "Función para invitar personas", "OK");
        }

        private async void BtnNotificaciones_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Notificaciones", "Aquí podrías configurar las notificaciones.", "OK");
        }

        private async void BtnComentarios_Clicked(object sender, EventArgs e)
        {
            await Launcher.Default.OpenAsync("mailto:rosanare.cr@gmail.com?subject=Comentarios%20de%20la%20App");
        }

        private async void BtnCalificar_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Calificar", "Gracias por considerar calificarnos 💖", "OK");
        }

        private async void BtnNovedades_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Novedades", "Próximamente verás nuestras últimas actualizaciones aquí 📰", "OK");
        }

        private async void BtnApps_Clicked(object sender, EventArgs e)
        {
            await Launcher.Default.OpenAsync("https://www.atlassian.com/software");
        }

        private async void BtnCompartir_Clicked(object sender, EventArgs e)
        {
            await Share.Default.RequestAsync(new ShareTextRequest
            {
                Title = "Compartir app",
                Text = "¡Descarga esta app genial! 💫",
                Uri = "https://CondoApp.com"
            });
        }

        private async void BtnAjustes_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Ajustes", "Opciones de configuración próximamente disponibles.", "OK");
        }
    }
}
