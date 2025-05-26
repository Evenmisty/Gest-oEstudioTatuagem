using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using GestaoEstudioTatuagem.Models;
using System;
using System.Threading.Tasks;

namespace GestaoEstudioTatuagem.ViewModels
{
    public partial class TatuadorViewModel : ObservableObject
    {
        // Lista de Tatuadores
        [ObservableProperty]
        private ObservableCollection<Tatuadores> listaTatuadores = new ObservableCollection<Tatuadores>();

        // Propriedades para Novo Tatuador
        [ObservableProperty]
        private string nome = string.Empty;

        [ObservableProperty]
        private string especialidade = string.Empty;

        // Construtor
        public TatuadorViewModel()
        {
            // Inicializando com alguns exemplos para testes (pode ser removido)
            listaTatuadores = new ObservableCollection<Tatuadores>
            {
                new Tatuadores { Nome = "Maria Tattoo", Especialidade = "Realismo" },
                new Tatuadores { Nome = "Pedro Tattoo", Especialidade = "Old School" }
            };
        }

        // Comandos
        [RelayCommand]
        private async Task AdicionarTatuador()
        {
            // Verificar se os campos obrigatórios estão preenchidos
            if (string.IsNullOrWhiteSpace(Nome))
            {
                await Shell.Current.DisplayAlert("Erro", "Preencha o nome do tatuador.", "OK");
                return;
            }

            // Criar novo tatuador e adicionar à lista
            var novoTatuador = new Tatuadores
            {
                Nome = Nome,
                Especialidade = Especialidade
            };

            listaTatuadores.Add(novoTatuador);
            LimparCampos();
        }

        [RelayCommand]
        private void RemoverTatuador(Tatuadores tatuador)
        {
            if (tatuador != null)
            {
                listaTatuadores.Remove(tatuador);
            }
        }

        [RelayCommand]
        private async Task EditarTatuador(Tatuadores tatuador)
        {
            if (tatuador == null)
                return;

            Nome = tatuador.Nome;
            Especialidade = tatuador.Especialidade;

            var confirmacao = await Shell.Current.DisplayAlert("Editar Tatuador", "Deseja salvar as alterações?", "Sim", "Não");

            if (confirmacao)
            {
                tatuador.Nome = Nome;
                tatuador.Especialidade = Especialidade;
                await Shell.Current.DisplayAlert("Sucesso", "Tatuador atualizado com sucesso!", "OK");
            }

            LimparCampos();
        }

        // Método para Limpar os Campos
        private void LimparCampos()
        {
            Nome = string.Empty;
            Especialidade = string.Empty;
        }
    }
}
