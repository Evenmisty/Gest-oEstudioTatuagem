using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Threading.Tasks;

namespace GestaoEstudioTatuagem.ViewModels
{
    public partial class ProntuarioEletronicoViewModel : ObservableObject
    {
        // Propriedades do cliente e da sessão
        [ObservableProperty]
        private string clienteNome = "João da Silva";

        [ObservableProperty]
        private string clienteNascimento = "15/06/1990";

        [ObservableProperty]
        private string tatuador = "Maria Oliveira";

        [ObservableProperty]
        private string dataSessao = "20/04/2025";

        // Detalhes do procedimento, observações e cuidados posteriores
        [ObservableProperty]
        private string detalhesProcedimento = string.Empty;

        [ObservableProperty]
        private string observacoes = string.Empty;

        [ObservableProperty]
        private string cuidadosPosteriores = string.Empty;

        // Comandos
        [RelayCommand]
        private async Task SelecionarFotos()
        {
            // Implementar a lógica de seleção de fotos
            await Task.CompletedTask;
        }

        [RelayCommand]
        private async Task Salvar()
        {
            // Lógica para salvar o prontuário eletrônico
            await Shell.Current.DisplayAlert("Prontuário Eletrônico", "Dados salvos com sucesso!", "OK");
        }

        [RelayCommand]
        private async Task Cancelar()
        {
            // Lógica para cancelar o processo
            await Shell.Current.DisplayAlert("Cancelado", "Ação cancelada!", "OK");
        }
    }
}
