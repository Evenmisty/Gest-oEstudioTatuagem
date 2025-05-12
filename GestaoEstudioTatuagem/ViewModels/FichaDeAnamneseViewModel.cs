using System;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GestaoEstudioTatuagem.Models;
using Microsoft.Maui.Controls;

namespace GestaoEstudioTatuagem.ViewModels
{
    public class FichaDeAnamneseViewModel : ObservableObject
    {
        // Propriedades vinculadas à UI
        private bool _preenchida;
        public bool Preenchida
        {
            get => _preenchida;
            set => SetProperty(ref _preenchida, value);
        }

        private string _observacoes = string.Empty;
        public string Observacoes
        {
            get => _observacoes;
            set => SetProperty(ref _observacoes, value);
        }

        // Comando para salvar
        public ICommand SalvarCommand { get; }

        public FichaDeAnamneseViewModel()
        {
            SalvarCommand = new AsyncRelayCommand(OnSalvarAsync);
        }

        private async System.Threading.Tasks.Task OnSalvarAsync()
        {
            // Cria objeto conforme Model
            var ficha = new FichaAnamnese
            {
                Preenchida = Preenchida,
                Observacoes = Observacoes
            };

            // TODO: aqui você pode persistir no banco SQLite (db.InsertAsync(ficha))…

            // Apenas demonstração
            await Application.Current.MainPage.DisplayAlert(
                "Sucesso",
                "Ficha salva com sucesso!",
                "OK");
        }
    }
}
