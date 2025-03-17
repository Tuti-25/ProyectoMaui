
using AplicacionMaui.Paginas;

namespace AplicacionMaui
{
    public partial class App : Application
    {
        public App(TestConnection testConnection)
        {
            InitializeComponent();
            TestConnection = testConnection;
        }

    }
}