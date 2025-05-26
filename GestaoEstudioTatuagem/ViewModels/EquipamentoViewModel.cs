using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using GestaoEstudioTatuagem.Models;
using System;
using System.Threading.Tasks;

namespace GestaoEstudioTatuagem.ViewModels
{
    public partial class EquipamentoViewModel : ObservableObject
    {
        // Lista de Equipamentos
        [ObservableProperty]
        private ObservableCollection<Equipamento> equipamentos = new ObservableCollection<Equipamento>();

        // Propriedades para Novo Equipamento
        [ObservableProperty]
        private string nome = string.Empty;

        [ObservableProperty]
        private string descricao = string.Empty;

        [ObservableProperty]
        private DateTime dataAquisicao = DateTime.Now;

        [ObservableProperty]
        private string status = "Ativo";

        [ObservableProperty]
        private string ultimaManutencaoDescricao = string.Empty;

        [ObservableProperty]
        private DateTime ultimaManutencaoData = DateTime.Now;

        // Construtor
        public EquipamentoViewModel()
        {
            // Inicializando com alguns exemplos para testes (pode ser removido)
            Equipamentos = new ObservableCollection<Equipamento>
            {
                new Equipamento
                {
                    Nome = "Máquina de Tatuagem",
                    Descricao = "Máquina rotativa para tatuagem",
                    DataAquisicao = DateTime.Now.AddMonths(-6),
                    Status = "Ativo",
                    UltimaManutencaoDescricao = "Troca de agulha",
                    UltimaManutencaoData = DateTime.Now.AddMonths(-1)
                },
                new Equipamento
                {
                    Nome = "Mesa de Esterilização",
                    Descricao = "Mesa para esterilização de materiais",
                    DataAquisicao = DateTime.Now.AddYears(-1),
                    Status = "Ativo",
                    UltimaManutencaoDescricao = "Limpeza completa",
                    UltimaManutencaoData = DateTime.Now.AddMonths(-2)
                }
            };
        }

        // Comandos
        [RelayCommand]
        private async Task AdicionarEquipamento()
        {
            // Verificar se os campos obrigatórios estão preenchidos
            if (string.IsNullOrWhiteSpace(Nome) || string.IsNullOrWhiteSpace(Descricao))
            {
                await Shell.Current.DisplayAlert("Erro", "Preencha o nome e a descrição do equipamento.", "OK");
                return;
            }

            // Criar novo equipamento e adicionar à lista
            var novoEquipamento = new Equipamento
            {
                Nome = Nome,
                Descricao = Descricao,
                DataAquisicao = DataAquisicao,
                Status = Status,
                UltimaManutencaoDescricao = UltimaManutencaoDescricao,
                UltimaManutencaoData = UltimaManutencaoData
            };

            Equipamentos.Add(novoEquipamento);
            LimparCampos();
        }

        [RelayCommand]
        private void RemoverEquipamento(Equipamento equipamento)
        {
            if (equipamento != null)
            {
                Equipamentos.Remove(equipamento);
            }
        }

        [RelayCommand]
        private async Task SalvarEquipamentos()
        {
            // Verificar se há equipamentos na lista
            if (Equipamentos.Count == 0)
            {
                await Shell.Current.DisplayAlert("Erro", "Nenhum equipamento adicionado.", "OK");
                return;
            }

            // Implementar lógica de salvamento (banco de dados ou API)
            await Shell.Current.DisplayAlert("Equipamentos", "Lista de equipamentos salva com sucesso!", "OK");
        }

        // Método para limpar os campos
        private void LimparCampos()
        {
            Nome = string.Empty;
            Descricao = string.Empty;
            DataAquisicao = DateTime.Now;
            Status = "Ativo";
            UltimaManutencaoDescricao = string.Empty;
            UltimaManutencaoData = DateTime.Now;
        }
    }
}
