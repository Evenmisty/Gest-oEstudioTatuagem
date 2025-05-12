using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using GestaoEstudioTatuagem.Models;
using System;

namespace GestaoEstudioTatuagem.ViewModels
{
    public partial class AgendaViewModel : ObservableObject
    {
        public ObservableCollection<AgendamentoModel> Agendamentos { get; set; }

        public AgendaViewModel()
        {
            // Dados de exemplo - aqui você buscaria os dados do seu serviço/banco de dados
            Agendamentos = new ObservableCollection<AgendamentoModel>
            {
                new AgendamentoModel { Id = 1, Horario = new DateTime(2025, 5, 11, 9, 0, 0), ClienteNome = "Carlos Souza", ClienteId = 101, TatuadorNome = "Ana Ribeiro", TatuadorId = 201 },
                new AgendamentoModel { Id = 2, Horario = new DateTime(2025, 5, 11, 11, 0, 0), ClienteNome = "Joana Lima", ClienteId = 102, TatuadorNome = "Marcelo Costa", TatuadorId = 202 },
                new AgendamentoModel { Id = 3, Horario = new DateTime(2025, 5, 11, 14, 0, 0), ClienteNome = "Lucas Pereira", ClienteId = 103, TatuadorNome = "Rafael Martins", TatuadorId = 203 }
            };
        }

        // Adicione aqui comandos para adicionar, editar, excluir agendamentos, etc.
    }
}