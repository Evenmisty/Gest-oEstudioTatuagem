using GestaoEstudioTatuagem.Models;
using GestaoEstudioTatuagem.ViewModels;
using Microsoft.Maui.Controls;

namespace GestaoEstudioTatuagem.Views
{
    [QueryProperty(nameof(Tatuador), "Tatuador")]
    public partial class DetalhesDoTatuador : ContentPage
    {
        public Tatuadores Tatuador
        {
            set => BindingContext = new DetalhesDoTatuadorViewModel(value);
        }

        public DetalhesDoTatuador()
        {
            InitializeComponent();
        }

        private async void OnVoltarClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
