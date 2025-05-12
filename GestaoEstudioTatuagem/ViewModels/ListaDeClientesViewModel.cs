using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GestaoEstudioTatuagem.Models;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoEstudioTatuagem.ViewModels
{
    public partial class ListaDeClientesViewModel : ObservableObject
    {
        private ObservableCollection<Clientes> _clients;
        public ObservableCollection<Clientes> Clients
        {
            get => _clients;
            set => SetProperty(ref _clients, value);
        }

        private string _searchQuery;
        public string SearchQuery
        {
            get => _searchQuery;
            set
            {
                SetProperty(ref _searchQuery, value);
                FilterClients();
            }
        }

        private string _selectedFilter;
        public string SelectedFilter
        {
            get => _selectedFilter;
            set
            {
                SetProperty(ref _selectedFilter, value);
                FilterClients();
            }
        }

        public ObservableCollection<string> FilterOptions { get; } = new()
        {
            "Ordem Alfabética",
            "Data de Cadastro"
        };

        private List<Clientes> allClients;

        public ListaDeClientesViewModel()
        {
            // Simulação de dados
            allClients = new List<Clientes>
            {
                new Clientes { Id = 1, Nome = "Carlos Souza", Telefone = "(11) 98765-4321", CPF = "123.456.789-00" },
                new Clientes { Id = 2, Nome = "Joana Silva", Telefone = "(11) 92345-6789", CPF = "111.222.333-44" },
                new Clientes { Id = 3, Nome = "Luis Pereira", Telefone = "(11) 91234-5678", CPF = "555.666.777-88" }
            };

            Clients = new ObservableCollection<Clientes>(allClients);
            SelectedFilter = FilterOptions.First();
        }

        private void FilterClients()
        {
            var filtered = allClients.Where(c =>
                string.IsNullOrWhiteSpace(SearchQuery) ||
                c.Nome.Contains(SearchQuery, System.StringComparison.OrdinalIgnoreCase) ||
                c.CPF.Contains(SearchQuery, System.StringComparison.OrdinalIgnoreCase));

            if (SelectedFilter == "Ordem Alfabética")
                filtered = filtered.OrderBy(c => c.Nome);
            else if (SelectedFilter == "Data de Cadastro")
                filtered = filtered.OrderBy(c => c.Id); // Altere para c.DataCadastro se for adicionar esse campo

            Clients = new ObservableCollection<Clientes>(filtered);
        }

        public IAsyncRelayCommand AddClientCommand => new AsyncRelayCommand(AddClient);

        private async Task AddClient()
        {
            await Application.Current.MainPage.DisplayAlert("Novo Cliente", "Abrir tela de cadastro de cliente", "OK");

        }
    }
}
