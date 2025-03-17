using AppMaui.Paginas;
using Demo.ApiClient2;
using Demo.ApiClient2.Models.ApiModels;

namespace AppMaui
{
    public partial class MainPage : ContentPage
    {
        private readonly DemoApiClientService _apiClient;
        public MainPage(DemoApiClientService apiClient)
        {
            InitializeComponent();
            _apiClient = apiClient;
        }

        private async void BtnAgregrar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new AddEditUsuario(_apiClient, null));

        }

        private async void btnVerUsuarios_Clicked(object sender, EventArgs e)
        {
            await LoadUsuarios();
        }

        private async void UsuarioListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var usuario = (Usuario)e.Item;
            var action = await DisplayActionSheet("Action", "Cancelar", null, "Editar", "Eliminar");

            switch (action)
            {
                case "Editar":
                    await Navigation.PushModalAsync(new AddEditUsuario(_apiClient, usuario));
                    break;
                case "Eliminar":
                    await _apiClient.DeleteUsuario(usuario.IdUsuario);
                    await LoadUsuarios();
                    LoadUsuarios();
                    break;
            }
        }

        private async Task LoadUsuarios()
        {
            var usuarios = await _apiClient.GetUsuarios();
            UsuarioListView.ItemsSource = usuarios;
        } 
    }

}
