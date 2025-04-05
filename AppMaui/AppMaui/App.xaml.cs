using AppMaui.Paginas;

namespace AppMaui
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new Casos());


        }
    }
}