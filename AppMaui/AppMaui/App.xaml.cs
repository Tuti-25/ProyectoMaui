using AppMaui.Paginas;
using Demo.ApiClient2;
using Demo.ApiClient2.Models.ApiModels;

namespace AppMaui
{
    public partial class App : Application
    {
        public App(LoginOrSignUp loginOrSignUp)
        {
            InitializeComponent();

            MainPage = loginOrSignUp;

        }
    }
}
