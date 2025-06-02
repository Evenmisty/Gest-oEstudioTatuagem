using Microsoft.Maui.Controls;
using GestaoEstudioTatuagem.Views;  

namespace GestaoEstudioTatuagem.Views
{
    public partial class EscolherTatuador : ContentPage
    {
        public EscolherTatuador()
        {
            InitializeComponent();
        }

        // Navegar para a tela de Agendamento
        private async void OnProximoClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AgendarTatuagem());
        }
    }
}
