using CommunityToolkit.Mvvm.ComponentModel;
using GestaoEstudioTatuagem.Models;

namespace GestaoEstudioTatuagem.ViewModels
{
    public partial class DetalhesDoTatuadorViewModel : ObservableObject
    {
        [ObservableProperty]
        private Tatuadores tatuador;

        public DetalhesDoTatuadorViewModel(Tatuadores tatuador)
        {
            Tatuador = tatuador;
        }
    }
}
