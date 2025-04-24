using Demo.ApiClient2;
using Demo.ApiClient2.Models;
using AppMaui;
using Demo.ApiClient2.Models.ApiModels;

namespace AppMaui.Paginas;

public partial class IngresarDatos : ContentPage
{
    private readonly DemoApiClientService _apiClient;
    public IngresarDatos(DemoApiClientService apiClient)
    {

        InitializeComponent();
        _apiClient = apiClient;
    }

    private async void btnAdd_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new Test(_apiClient, null));
    }

    private async void btnShowProducts_Clicked(object sender, EventArgs e)
    {
        await LoadUsuarios();
    }

    private async void productListView_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        var usuario = (Usuario)e.Item;
        var action = await DisplayActionSheet("Action", "Cancel", null, "Edit", "Delete");

        switch (action)
        {
            case "Edit":
                await Navigation.PushModalAsync(new Test(_apiClient, usuario));
                break;
            case "Delete":
                await _apiClient.DeleteUsuario(usuario.IdUsuario);
                await LoadUsuarios();
                break;
        }

    }
    private async Task LoadUsuarios() { 
    
        var usuario = await _apiClient.GetUsuarios();
        productListView.ItemsSource = usuario;
    }
}

