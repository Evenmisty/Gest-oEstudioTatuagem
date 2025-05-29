using GestaoEstudioTatuagem.ViewModels;
using Microsoft.Maui.Controls;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using Microsoft.Maui.Storage;

namespace GestaoEstudioTatuagem.Views
{
    public partial class FichaDeAnamnese : ContentPage
    {
        public ObservableCollection<ImageSource> ImagensSelecionadas { get; set; } = new();

        public FichaDeAnamnese()
        {
            InitializeComponent();
            BindingContext = new ProntuarioEletronicoViewModel(); // Usando o ViewModel para manter o padrão MVVM
            FotosPreview.ItemsSource = ImagensSelecionadas;
        }

        private async void SelecionarFotos_Clicked(object sender, EventArgs e)
        {
            try
            {
                var resultados = await FilePicker.PickMultipleAsync(new PickOptions
                {
                    PickerTitle = "Selecione as fotos do procedimento",
                    FileTypes = FilePickerFileType.Images
                });

                if (resultados != null)
                {
                    ImagensSelecionadas.Clear();
                    foreach (var arquivo in resultados)
                    {
                        using var stream = await arquivo.OpenReadAsync();
                        var imagem = ImageSource.FromStream(() => stream);
                        ImagensSelecionadas.Add(imagem);
                    }
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", $"Falha ao carregar imagens: {ex.Message}", "OK");
            }
        }

        private async void Salvar_Clicked(object sender, EventArgs e)
        {
            if (BindingContext is ProntuarioEletronicoViewModel viewModel)
            {
                await viewModel.SalvarCommand.ExecuteAsync(null); // Usando o comando do ViewModel
            }
        }

        private async void Cancelar_Clicked(object sender, EventArgs e)
        {
            if (BindingContext is ProntuarioEletronicoViewModel viewModel)
            {
                await viewModel.CancelarCommand.ExecuteAsync(null); // Usando o comando do ViewModel
            }
        }
    }
}
