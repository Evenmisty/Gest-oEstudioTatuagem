using GestaoEstudioTatuagem.ViewModels;

namespace GestaoEstudioTatuagem.Views;

public partial class TelaDeCadastro : ContentPage
{
    public TelaDeCadastro()
    {
        InitializeComponent();
        BindingContext = new TelaDeCadastroViewModel();
    }
}
