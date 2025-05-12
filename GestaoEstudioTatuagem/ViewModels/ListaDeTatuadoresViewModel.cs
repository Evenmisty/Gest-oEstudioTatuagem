using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GestaoEstudioTatuagem.Models;
using GestaoEstudioTatuagem.Views;
using System.Collections.ObjectModel;

namespace GestaoEstudioTatuagem.ViewModels
{
    public partial class ListaDeTatuadoresViewModel : ObservableObject
    {
        public ObservableCollection<Tatuadores> Tatuadores { get; set; }

        public ListaDeTatuadoresViewModel()
        {
            Tatuadores = new ObservableCollection<Tatuadores>
            {
                new() { Id = 1, Nome = "Lucas Costa", Especialidade = "Blackwork" },
                new() { Id = 2, Nome = "Ana Souza", Especialidade = "Pontilhismo" }
                // Carregar de um banco de dados depois, se necessário
            };
        }

        [RelayCommand]
        async Task NavegarParaDetalhes(Tatuadores tatuador)
        {
            if (tatuador == null)
                return;

            await Shell.Current.GoToAsync(nameof(DetalhesDoTatuador), new Dictionary<string, object>
            {
                ["TatuadorSelecionado"] = tatuador
            });
        }
    }
}
