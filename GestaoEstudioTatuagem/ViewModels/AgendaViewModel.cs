using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using GestaoEstudioTatuagem.Models;
using System;
using System.Threading.Tasks;

namespace GestaoEstudioTatuagem.ViewModels
{
    public partial class AgendaViewModel : ObservableObject
    {
        // Lista de Sessões na Agenda
        [ObservableProperty]
        private ObservableCollection<Sessao> sessoes = new ObservableCollection<Sessao>();

        // Propriedades para Nova Sessão
        [ObservableProperty]
        private string descricaoTatuagem = string.Empty;

        [ObservableProperty]
        private DateTime dataSessao = DateTime.Now;

        [ObservableProperty]
        private string clienteNome = string.Empty;

        [ObservableProperty]
        private string tatuadorNome = string.Empty;

        // Construtor
        public AgendaViewModel()
        {
            // Inicializando com alguns exemplos para testes (pode ser removido)
            Sessoes = new ObservableCollection<Sessao>
            {
                new Sessao
                {
                    DescricaoTatuagem = "Tatuagem de Dragão",
                    DataSessao = DateTime.Now.AddDays(1),
                    Cliente = new Clientes { Nome = "João Silva" },
                    Tatuador = new Tatuadores { Nome = "Maria Tattoo" }
                },
                new Sessao
                {
                    DescricaoTatuagem = "Tatuagem Tribal",
                    DataSessao = DateTime.Now.AddDays(2),
                    Cliente = new Clientes { Nome = "Ana Costa" },
                    Tatuador = new Tatuadores { Nome = "Pedro Tattoo" }
                }
            };
        }

        // Comandos
        [RelayCommand]
        private async Task AdicionarSessao()
        {
            // Verificar se os campos obrigatórios estão preenchidos
            if (string.IsNullOrWhiteSpace(DescricaoTatuagem) ||
                string.IsNullOrWhiteSpace(ClienteNome) ||
                string.IsNullOrWhiteSpace(TatuadorNome))
            {
                await Shell.Current.DisplayAlert("Erro", "Preencha todos os campos obrigatórios.", "OK");
                return;
            }

            // Criar nova sessão e adicionar à lista
            var novaSessao = new Sessao
            {
                DescricaoTatuagem = DescricaoTatuagem,
                DataSessao = DataSessao,
                Cliente = new Clientes { Nome = ClienteNome },
                Tatuador = new Tatuadores { Nome = TatuadorNome }
            };

            Sessoes.Add(novaSessao);
            LimparCampos();
        }

        [RelayCommand]
        private void RemoverSessao(Sessao sessao)
        {
            if (sessao != null)
            {
                Sessoes.Remove(sessao);
            }
        }

        [RelayCommand]
        private async Task SalvarAgenda()
        {
            // Verificar se há sessões na agenda
            if (Sessoes.Count == 0)
            {
                await Shell.Current.DisplayAlert("Erro", "A agenda está vazia.", "OK");
                return;
            }

            // Implementar lógica de salvamento (banco de dados ou API)
            await Shell.Current.DisplayAlert("Agenda", "Agenda salva com sucesso!", "OK");
        }

        // Método para limpar os campos
        private void LimparCampos()
        {
            DescricaoTatuagem = string.Empty;
            DataSessao = DateTime.Now;
            ClienteNome = string.Empty;
            TatuadorNome = string.Empty;
        }
    }
}
