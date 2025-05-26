using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoEstudioTatuagem.ViewModels
{
    public partial class ProntuarioEletronicoViewModel : ObservableObject
    {
        // Propriedades do Cliente e da Sessão
        [ObservableProperty]
        private string clienteNome = string.Empty;

        [ObservableProperty]
        private DateTime clienteNascimento = DateTime.MinValue;

        [ObservableProperty]
        private string tatuadorNome = string.Empty;

        [ObservableProperty]
        private DateTime dataSessao = DateTime.Now;

        // Detalhes do procedimento e observações
        [ObservableProperty]
        private string detalhesProcedimento = string.Empty;

        [ObservableProperty]
        private string observacoes = string.Empty;

        [ObservableProperty]
        private string cuidadosPosteriores = string.Empty;

        // Propriedade para armazenar as fotos selecionadas
        [ObservableProperty]
        private List<string> fotosSelecionadas = new List<string>();

        // Construtor
        public ProntuarioEletronicoViewModel()
        {
            // Inicializando com valores padrão
            LimparCampos();
        }

        // Comando para Selecionar Fotos
        [RelayCommand]
        private async Task SelecionarFotos()
        {
            // Simulação de seleção de fotos (pode ser adaptado para usar o FilePicker)
            FotosSelecionadas.Add("FotoExemplo1.jpg");
            FotosSelecionadas.Add("FotoExemplo2.jpg");

            await Shell.Current.DisplayAlert("Fotos Selecionadas", "Fotos foram selecionadas com sucesso!", "OK");
        }

        // Comando para Salvar o Prontuário
        [RelayCommand]
        private async Task Salvar()
        {
            // Verificar se os dados estão completos antes de salvar
            if (string.IsNullOrWhiteSpace(clienteNome) || string.IsNullOrWhiteSpace(detalhesProcedimento))
            {
                await Shell.Current.DisplayAlert("Erro", "Preencha todos os campos obrigatórios.", "OK");
                return;
            }

            // Simular salvamento (pode ser integrado com banco de dados)
            await Shell.Current.DisplayAlert("Sucesso", "Prontuário Eletrônico salvo com sucesso!", "OK");
            LimparCampos();
        }

        // Comando para Cancelar o Preenchimento
        [RelayCommand]
        private async Task Cancelar()
        {
            var confirmacao = await Shell.Current.DisplayAlert("Cancelar", "Deseja cancelar o preenchimento do prontuário?", "Sim", "Não");
            if (confirmacao)
            {
                LimparCampos();
            }
        }

        // Método para Limpar os Campos
        private void LimparCampos()
        {
            clienteNome = string.Empty;
            clienteNascimento = DateTime.MinValue;
            tatuadorNome = string.Empty;
            dataSessao = DateTime.Now;
            detalhesProcedimento = string.Empty;
            observacoes = string.Empty;
            cuidadosPosteriores = string.Empty;
            fotosSelecionadas.Clear();
        }
    }
}
