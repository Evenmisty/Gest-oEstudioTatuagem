using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GestaoEstudioTatuagem.Models;
using System.Threading.Tasks;

namespace GestaoEstudioTatuagem.ViewModels
{
    public partial class TelaDeCadastroViewModel : ObservableObject
    {
        [ObservableProperty]
        private string fullName = string.Empty;

        [ObservableProperty]
        private string email = string.Empty;

        [ObservableProperty]
        private string password = string.Empty;

        [ObservableProperty]
        private string confirmPassword = string.Empty;

        // Comando para Registrar Usuário
        [RelayCommand]
        private async Task Register()
        {
            if (string.IsNullOrWhiteSpace(FullName) ||
                string.IsNullOrWhiteSpace(Email) ||
                string.IsNullOrWhiteSpace(Password))
            {
                await Shell.Current.DisplayAlert("Erro", "Preencha todos os campos obrigatórios.", "OK");
                return;
            }

            if (!Email.Contains("@") || !Email.Contains("."))
            {
                await Shell.Current.DisplayAlert("Erro", "Email inválido.", "OK");
                return;
            }

            if (Password.Length < 6)
            {
                await Shell.Current.DisplayAlert("Erro", "A senha deve ter pelo menos 6 caracteres.", "OK");
                return;
            }

            if (Password != ConfirmPassword)
            {
                await Shell.Current.DisplayAlert("Erro", "As senhas não coincidem.", "OK");
                return;
            }

            var usuarioExistente = await App.Db.GetUsuarioByEmailAsync(Email.ToLower());
            if (usuarioExistente != null)
            {
                await Shell.Current.DisplayAlert("Erro", "Usuário já registrado.", "OK");
                return;
            }

            var usuario = new Usuario
            {
                Login = Email.ToLower(),
                SenhaHash = Password,
                Nome = FullName
            };

            await App.Db.SaveUsuarioAsync(usuario);
            await Shell.Current.DisplayAlert("Sucesso", "Cadastro realizado com sucesso!", "OK");
            await Shell.Current.GoToAsync("//TelaDeLogin");
        }

        // Comando para Voltar ao Login
        [RelayCommand]
        private async Task GoToLogin()
        {
            await Shell.Current.GoToAsync("//TelaDeLogin");
        }
    }
}
