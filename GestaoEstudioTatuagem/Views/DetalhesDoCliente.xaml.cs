using GestaoEstudioTatuagem.Models;
using GestaoEstudioTatuagem.ViewModels;

namespace GestaoEstudioTatuagem.Views
{
    public partial class DetalhesDoCliente : ContentPage
    {
        public DetalhesDoCliente(Clientes cliente)
        {
            InitializeComponent();
            BindingContext = new DetalhesDoClienteViewModel(cliente);
        }
    }
}
