using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Threading.Tasks;
using GestaoEstudioTatuagem.Models;

namespace GestaoEstudioTatuagem.ViewModels
{
    public partial class SessaoViewModel : ObservableObject
    {
        // Propriedades da Sessão
        [ObservableProperty]
        private string descricaoTatuagem = string.Empty;

        [ObservableProperty]
        private DateTime dataSessao = DateTime.Now;

        [ObservableProperty]
        private string clienteNome = string.Empty;

        [ObservableProperty]
        private string tatuadorNome = string.Empty;

        // Instância do Modelo de Sessão
        private Sessao sessao = new Sessao();

        // Comandos
        [RelayCommand]
        private async Task Salvar()
        {
            // Verificar se os campos obrigatórios estão preenchidos
            if (string.IsNullOrWhiteSpace(DescricaoTatuagem) || string.IsNullOrWhiteSpace(ClienteNome) || string.IsNullOrWhiteSpace(TatuadorNome))
            {
                await Shell.Current.DisplayAlert("Erro", "Preencha todos os campos obrigatórios.", "OK");
                return;
            }

            // Preencher o modelo com os dados do ViewModel
            sessao.DescricaoTatuagem = DescricaoTatuagem;
            sessao.DataSessao = DataSessao;
            sessao.Cliente = new Clientes { Nome = ClienteNome };
            sessao.Tatuador = new Tatuadores { Nome = TatuadorNome };

            // Implementar lógica de salvamento (banco de dados ou API)
            await Shell.Current.DisplayAlert("Sessão de Tatuagem", "Dados da sessão salvos com sucesso!", "OK");
        }

        [RelayCommand]
        private async Task Cancelar()
        {
            // Limpar os campos e redefinir os valores padrão
            DescricaoTatuagem = string.Empty;
            DataSessao = DateTime.Now;
            ClienteNome = string.Empty;
            TatuadorNome = string.Empty;

            await Shell.Current.DisplayAlert("Cancelado", "Ação cancelada!", "OK");
        }
    }
}
