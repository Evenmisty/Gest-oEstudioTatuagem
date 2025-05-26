using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;
using GestaoEstudioTatuagem.Models;

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

        // Comando para realizar o login
        [RelayCommand]
        private async Task Submit()
        {
            // Simulação de login (a lógica real de autenticação pode ser adicionada aqui)
            if (Email == "teste@exemplo.com" && Password == "123456")
            {
                await Shell.Current.GoToAsync("//Dashboard");
            }
            else
            {
                await Shell.Current.DisplayAlert("Erro", "Email ou senha incorretos.", "OK");
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
            await Shell.Current.GoToAsync("//TelaDeCadastro");
        }

    }
}
