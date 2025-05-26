using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GestaoEstudioTatuagem.Models;
using System.Threading.Tasks;

namespace GestaoEstudioTatuagem.ViewModels
{
    public partial class FichaDeAnamneseViewModel : ObservableObject
    {
        // Propriedades Vinculadas à UI
        [ObservableProperty]
        private bool _preenchida;

        [ObservableProperty]
        private string _observacoes = string.Empty;

        [ObservableProperty]
        private string _cuidadosPosteriores = string.Empty;

        // Construtor
        public FichaDeAnamneseViewModel()
        {
            // Inicializando com valores padrão
            Preenchida = false;
            Observacoes = string.Empty;
            CuidadosPosteriores = string.Empty;
        }

        // Comando para Salvar a Ficha de Anamnese
        [RelayCommand]
        private async Task Salvar()
        {
            if (string.IsNullOrWhiteSpace(Observacoes))
            {
                await Shell.Current.DisplayAlert("Erro", "As observações não podem estar vazias.", "OK");
                return;
            }

            // Implementar lógica de salvamento (exemplo de simulação)
            await Shell.Current.DisplayAlert("Sucesso", "Ficha de Anamnese salva com sucesso!", "OK");
            LimparCampos();
        }

        // Comando para Cancelar o Preenchimento da Ficha
        [RelayCommand]
        private async Task Cancelar()
        {
            var confirmacao = await Shell.Current.DisplayAlert("Cancelar", "Deseja cancelar o preenchimento da ficha?", "Sim", "Não");
            if (confirmacao)
            {
                LimparCampos();
            }
        }

        // Método para Limpar os Campos
        private void LimparCampos()
        {
            Preenchida = false;
            Observacoes = string.Empty;
            CuidadosPosteriores = string.Empty;
        }
    }
}
