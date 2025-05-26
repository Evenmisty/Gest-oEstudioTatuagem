using GestaoEstudioTatuagem.ViewModels;

namespace GestaoEstudioTatuagem.Views
{
    public partial class DetalhesDaSessao : ContentPage
    {
        public DetalhesDaSessao()
        {
            InitializeComponent();
            BindingContext = new DetalhesDaSessaoViewModel();
        }
    }
}
