using GestaoEstudioTatuagem.ViewModels;

namespace GestaoEstudioTatuagem.Views
{
    public partial class TatuadorPage : ContentPage
    {
        public TatuadorPage()
        {
            InitializeComponent();
            BindingContext = new TatuadorViewModel();
        }
    }
}
