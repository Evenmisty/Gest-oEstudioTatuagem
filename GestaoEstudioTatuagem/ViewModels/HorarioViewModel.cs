using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using GestaoEstudioTatuagem.Models;
using System;
using System.Threading.Tasks;

namespace GestaoEstudioTatuagem.ViewModels
{
    public partial class HorarioViewModel : ObservableObject
    {
        // Lista de Horários
        [ObservableProperty]
        private ObservableCollection<Horario> horarios = new ObservableCollection<Horario>();

        // Propriedades para Novo Horário
        [ObservableProperty]
        private string diaSemana = string.Empty;

        [ObservableProperty]
        private TimeSpan horaInicio = new TimeSpan(9, 0, 0); // 09:00

        [ObservableProperty]
        private TimeSpan horaFim = new TimeSpan(18, 0, 0); // 18:00

        [ObservableProperty]
        private string tatuadorNome = string.Empty;

        [ObservableProperty]
        private int tatuadorId;

        // Construtor
        public HorarioViewModel()
        {
            // Inicializando com alguns exemplos para testes (pode ser removido)
            Horarios = new ObservableCollection<Horario>
            {
                new Horario
                {
                    DiaSemana = "Segunda-feira",
                    HoraInicio = new TimeSpan(9, 0, 0),
                    HoraFim = new TimeSpan(18, 0, 0),
                    Tatuador = new Tatuadores { Nome = "Maria Tattoo" }
                },
                new Horario
                {
                    DiaSemana = "Sexta-feira",
                    HoraInicio = new TimeSpan(10, 0, 0),
                    HoraFim = new TimeSpan(20, 0, 0),
                    Tatuador = new Tatuadores { Nome = "Pedro Tattoo" }
                }
            };
        }

        // Comandos
        [RelayCommand]
        private async Task AdicionarHorario()
        {
            // Verificar se os campos obrigatórios estão preenchidos
            if (string.IsNullOrWhiteSpace(DiaSemana) || string.IsNullOrWhiteSpace(TatuadorNome))
            {
                await Shell.Current.DisplayAlert("Erro", "Preencha o dia da semana e o nome do tatuador.", "OK");
                return;
            }

            // Verificar se o horário de início é anterior ao horário de fim
            if (HoraInicio >= HoraFim)
            {
                await Shell.Current.DisplayAlert("Erro", "O horário de início deve ser anterior ao horário de fim.", "OK");
                return;
            }

            // Criar novo horário e adicionar à lista
            var novoHorario = new Horario
            {
                DiaSemana = DiaSemana,
                HoraInicio = HoraInicio,
                HoraFim = HoraFim,
                Tatuador = new Tatuadores { Nome = TatuadorNome, Id = TatuadorId }
            };

            Horarios.Add(novoHorario);
            LimparCampos();
        }

        [RelayCommand]
        private void RemoverHorario(Horario horario)
        {
            if (horario != null)
            {
                Horarios.Remove(horario);
            }
        }

        [RelayCommand]
        private async Task SalvarHorarios()
        {
            // Verificar se há horários na lista
            if (Horarios.Count == 0)
            {
                await Shell.Current.DisplayAlert("Erro", "Nenhum horário adicionado.", "OK");
                return;
            }

            // Implementar lógica de salvamento (banco de dados ou API)
            await Shell.Current.DisplayAlert("Horários", "Lista de horários salva com sucesso!", "OK");
        }

        // Método para limpar os campos
        private void LimparCampos()
        {
            DiaSemana = string.Empty;
            HoraInicio = new TimeSpan(9, 0, 0);
            HoraFim = new TimeSpan(18, 0, 0);
            TatuadorNome = string.Empty;
            TatuadorId = 0;
        }
    }
}
