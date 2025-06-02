using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace GestaoEstudioTatuagem.ViewModels
{
    public class Estudio
    {
        public string Nome { get; set; }
        public string LogoUrl { get; set; }
    }

    public partial class EscolherEstudioViewModel : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<Estudio> listaEstudios;

        [ObservableProperty]
        Estudio estudioSelecionado;

        public ICommand ProximoCommand { get; }

        public EscolherEstudioViewModel()
        {
            ListaEstudios = new ObservableCollection<Estudio>
            {
                new Estudio { Nome = "Estúdio Tribal", LogoUrl = "logo_tribal.png" },
                new Estudio { Nome = "Ink House", LogoUrl = "logo_inkhouse.png" },
                new Estudio { Nome = "Arte na Pele", LogoUrl = "logo_artenapel.png" },
            };

            ProximoCommand = new RelayCommand(OnProximo, CanExecuteProximo);
        }

        private bool CanExecuteProximo()
        {
            return EstudioSelecionado != null;
        }

        private async void OnProximo()
        {
            if (EstudioSelecionado == null)
                return;

            await App.Current.MainPage.DisplayAlert("Estúdio Selecionado",
                $"Você escolheu: {EstudioSelecionado.Nome}", "OK");

            await Shell.Current.GoToAsync("//EscolherTatuador");
        }

    }
}
