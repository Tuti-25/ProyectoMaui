using AppMaui.Paginas;

namespace AppMaui
{
    public partial class App : Application
    {
        public App(IngresarDatos ingresarDatos)
        {
            InitializeComponent();
            MainPage = ingresarDatos;

        }
    }
}
