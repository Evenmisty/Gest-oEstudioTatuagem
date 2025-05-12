using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GestaoEstudioTatuagem.Models;
using System;
using System.Threading.Tasks;

namespace GestaoEstudioTatuagem.ViewModels
{
    public partial class TelaDeLoginViewModel : ObservableObject
    {
        [ObservableProperty]
        private bool isLogin = true;

        [ObservableProperty]
        private bool isPasswordHidden = true;

        [ObservableProperty]
        private bool isConfirmPasswordHidden = true;

        // Campos de entrada
        [ObservableProperty]
        private string fullName = string.Empty;

        [ObservableProperty]
        private string email = string.Empty;

        [ObservableProperty]
        private string phone = string.Empty;

        [ObservableProperty]
        private string address = string.Empty;

        [ObservableProperty]
        private string cpf = string.Empty; // ✅ Corrigido: propriedade CPF

        [ObservableProperty]
        private DateTime birthDate = DateTime.Today;

        [ObservableProperty]
        private string password = string.Empty;

        [ObservableProperty]
        private string confirmPassword = string.Empty;

        // Propriedades derivadas
        public bool IsNotLogin => !IsLogin;

        public string FormSubtitle => IsLogin ? "Acesse sua conta para continuar" : "Crie sua conta para começar";

        public string SubmitText => IsLogin ? "Entrar" : "Cadastrar";

        public string ToggleText => IsLogin ? "Não tem uma conta?" : "Já tem uma conta?";

        public string ToggleLink => IsLogin ? "Cadastre-se" : "Entrar";

        [RelayCommand]
        private void ToggleForm()
        {
            IsLogin = !IsLogin;
            OnPropertyChanged(nameof(IsNotLogin));
            OnPropertyChanged(nameof(FormSubtitle));
            OnPropertyChanged(nameof(SubmitText));
            OnPropertyChanged(nameof(ToggleText));
            OnPropertyChanged(nameof(ToggleLink));
        }

        [RelayCommand]
        private void TogglePassword() => IsPasswordHidden = !IsPasswordHidden;

        [RelayCommand]
        private void ToggleConfirmPassword() => IsConfirmPasswordHidden = !IsConfirmPasswordHidden;

        [RelayCommand]
        private async Task ForgotPassword()
        {
            await Shell.Current.DisplayAlert("Recuperar senha", "Instruções enviadas para seu email.", "OK");
        }

        [RelayCommand]
        private async Task Submit()
        {
            if (IsLogin)
                await Login();
            else
                await Register();
        }

        private async Task Login()
        {
            await Shell.Current.DisplayAlert("Login", $"Email: {Email}\nSenha: {Password}", "OK");
        }

        private async Task Register()
        {
            var cliente = new Clientes
            {
                Nome = FullName,
                Email = Email,
                Telefone = Phone,
                Endereco = Address,
                CPF = Cpf,
                DataNascimento = DateOnly.FromDateTime(BirthDate)
            };

            await Shell.Current.DisplayAlert("Cadastro",
                $"Nome: {cliente.Nome}\nEmail: {cliente.Email}\nTelefone: {cliente.Telefone}\nEndereço: {cliente.Endereco}\nNascimento: {cliente.DataNascimento:dd/MM/yyyy}\nCPF: {cliente.CPF}",
                "OK");
        }
    }
}
