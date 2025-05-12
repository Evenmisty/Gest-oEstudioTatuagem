using Microsoft.Maui.Controls;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using Microsoft.Maui.Storage;

namespace GestaoEstudioTatuagem.Views
{
    public partial class ProntuarioEletronico : ContentPage
    {
        public ObservableCollection<ImageSource> ImagensSelecionadas { get; set; } = new();

        public ProntuarioEletronico()
        {
            InitializeComponent();
            BindingContext = this;
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
            // Aqui você pode integrar com banco de dados ou ViewModel
            await DisplayAlert("Sucesso", "Prontuário salvo com sucesso!", "OK");
        }

        private async void Cancelar_Clicked(object sender, EventArgs e)
        {
            var confirmacao = await DisplayAlert("Cancelar", "Deseja cancelar o preenchimento do prontuário?", "Sim", "Não");
            if (confirmacao)
                await Navigation.PopAsync();
        }
    }
}
