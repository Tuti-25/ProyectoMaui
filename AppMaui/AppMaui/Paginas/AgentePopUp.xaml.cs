using CommunityToolkit.Maui.Views;

namespace AppMaui.Popups
{
    public partial class AgentePopUp : Popup
    {
        public AgentePopUp()
        {
            InitializeComponent();
        }

        private void OnAcceptClicked(object sender, EventArgs e)
        {
            string idAgente = EntryIdAgente.Text?.Trim();
            string cedulaAgente = EntryCedulaAgente.Text?.Trim();

            if (string.IsNullOrWhiteSpace(idAgente) || string.IsNullOrWhiteSpace(cedulaAgente))
            {
                Close(null);
                return;
            }

            var agente = new
            {
                IdAgente = idAgente,
                CedulaAgente = cedulaAgente
            };

            Close(agente);
        }

        private void OnCancelClicked(object sender, EventArgs e)
        {
            Close(null);
        }
    }
}
