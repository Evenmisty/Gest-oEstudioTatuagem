using GestaoEstudioTatuagem.Models;
using Microsoft.Maui.Controls;

namespace GestaoEstudioTatuagem.Views
{
    public partial class ListaDeTatuadores : ContentPage
    {
        public ListaDeTatuadores()
        {
            InitializeComponent(); // Certifique-se de que o arquivo XAML está correto
        }

        private async void OnTatuadorSelecionado(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.FirstOrDefault() is Tatuadores tatuadorSelecionado)
            {
                // Navega para os detalhes do tatuador
                await Shell.Current.GoToAsync(nameof(DetalhesDoTatuador), true,
                    new Dictionary<string, object> { { "Tatuador", tatuadorSelecionado } });

                // Limpa a seleção para permitir re-selecionar o mesmo item depois
                ((CollectionView)sender).SelectedItem = null;
            }
        }
    }
}
