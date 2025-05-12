using GestaoEstudioTatuagem.ViewModels;

namespace GestaoEstudioTatuagem.Views
{
    public partial class Agenda : ContentPage
    {
        public Agenda()
        {
            InitializeComponent();
            BindingContext = new AgendaViewModel();
        }
    }
}