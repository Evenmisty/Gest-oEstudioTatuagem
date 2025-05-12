using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace GestaoEstudioTatuagem.ViewModels
{
    public partial class DashboardViewModel : ObservableObject
    {
        [ObservableProperty]
        private int agendamentosDoDia = 3;

        [ObservableProperty]
        private int novosClientesMes = 8;

        [ObservableProperty]
        private decimal faturamentoEstimado = 3600.00m;

        // Alteração aqui: definindo como ObservableCollection<ProximoAgendamento>
        [ObservableProperty]
        private ObservableCollection<ProximoAgendamento> proximosAgendamentos;

        [ObservableProperty]
        private ObservableCollection<string> alertas;

        public DashboardViewModel()
        {
            // Agora a lista é de ProximoAgendamento
            ProximosAgendamentos = new ObservableCollection<ProximoAgendamento>
            {
                new ProximoAgendamento { Hora = "10:00", Cliente = "Ana Lopes", Tatuador = "Rafael Costa" },
                new ProximoAgendamento { Hora = "13:00", Cliente = "Bruno Lima", Tatuador = "Lucas Prado" },
                new ProximoAgendamento { Hora = "15:30", Cliente = "Carla Nunes", Tatuador = "Marina Dias" }
            };

            Alertas = new ObservableCollection<string>
            {
                "Equipamento 'Dermógrafo Pro' em manutenção.",
                "Ficha de anamnese pendente para o cliente Joana Dias."
            };
        }

        [RelayCommand]
        private async Task VerAgendaCompleta()
        {
            await Shell.Current.GoToAsync("//Agenda");
        }
    }

    // Classe para representar o ProximoAgendamento
    public class ProximoAgendamento
    {
        public string Hora { get; set; }
        public string Cliente { get; set; }
        public string Tatuador { get; set; }

        public string Descricao => $"{Hora} - {Cliente} (Tatuador: {Tatuador})";
    }
}