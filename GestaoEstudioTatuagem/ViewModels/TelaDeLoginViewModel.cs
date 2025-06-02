using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;
using GestaoEstudioTatuagem.Models;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Text;
using GestaoEstudioTatuagem.Helpers;

namespace GestaoEstudioTatuagem.ViewModels
{
    public partial class TelaDeLoginViewModel : ObservableObject
    {
        [ObservableProperty]
        private string email = string.Empty;

        [ObservableProperty]
        private string password = string.Empty;

        [ObservableProperty]
        private bool isPasswordHidden = true;

        // Comando para alternar a visibilidade da senha
        [RelayCommand]
        private void TogglePassword()
        {
            IsPasswordHidden = !IsPasswordHidden;
        }

        [ObservableProperty]
        private string perfil; // "Cliente" ou "Tatuador"
        [RelayCommand]
        private async Task Submit()
        {
            if (string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Password))
            {
                await Shell.Current.DisplayAlert("Erro", "Preencha todos os campos.", "OK");
                return;
            }

            var usuario = await App.Db.GetUsuarioByEmailAsync(Email.Trim());

            if (usuario != null && usuario.SenhaHash == PasswordHelper.HashPassword(Password))
            {
                if (usuario.Permissoes.Contains(Perfil))
                {
                    // Perfil bate, navega para a tela correta:
                    if (Perfil == "Tatuador")
                        await Shell.Current.GoToAsync("//Dashboard");
                    else if (Perfil == "Cliente")
                        await Shell.Current.GoToAsync("//EscolherEStudio");
                }
                else
                {
                    await Shell.Current.DisplayAlert("Erro", $"Este usuário não tem permissão para logar como {Perfil}.", "OK");
                }
            }
            else
            {
                await Shell.Current.DisplayAlert("Erro", "Email ou senha inválidos.", "OK");
            }
        }

        // Comando para recuperar senha (opcional)
        [RelayCommand]
        private async Task ForgotPassword()
        {
            await Shell.Current.DisplayAlert("Recuperar senha", "Instruções enviadas para seu email.", "OK");
        }

        // ✅ Comando para navegar para a Tela de Cadastro

        [RelayCommand]
        private async Task GoToCadastro()
        {
            if (string.IsNullOrWhiteSpace(Perfil))
            {
                await Shell.Current.DisplayAlert("Erro", "Perfil desconhecido para navegação.", "OK");
                return;
            }

            string rota = Perfil == "Tatuador" ? "CadastroTatuador" : "CadastroCliente";
            await Shell.Current.GoToAsync($"//{rota}");
        }

    }
}
