using CommunityToolkit.Maui.Views;
using Demo.ApiClient2.Models.ApiModels;
using System.Windows.Input;

namespace AppMaui.Popups;

public partial class SeveridadesPopup : Popup
{
    public ICommand SeleccionarSeveridadCommand { get; }

    public SeveridadesPopup(List<Severidad> severidades)
    {
        InitializeComponent();
        SeveridadesList.BindingContext = this;
        SeveridadesList.ItemsSource = severidades;

        SeleccionarSeveridadCommand = new Command<Severidad>((sev) =>
        {
            Close(sev);
        });
    }

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        if (e.Parameter is Severidad severidadSeleccionada)
        {
            Close(severidadSeleccionada);
        }
    }

    private void SeveridadesList_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {

    }
}
