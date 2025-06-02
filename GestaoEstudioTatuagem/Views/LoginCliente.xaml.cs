using Microsoft.Maui.Controls;
using GestaoEstudioTatuagem.ViewModels;

namespace GestaoEstudioTatuagem.Views
{
    public partial class LoginCliente : ContentPage
    {
        public LoginCliente()
        {
            InitializeComponent();
            var vm = new TelaDeLoginViewModel();
            vm.Perfil = "Cliente";
            BindingContext = vm;
        }
    }
}