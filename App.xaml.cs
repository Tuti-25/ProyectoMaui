using Microsoft.Maui.Controls;

namespace MenuView
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();  // Inicializa los componentes de la UI
            MainPage = new AppShell();  // Configura la página principal
        }
    }
}
