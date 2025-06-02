using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestaoEstudioTatuagem.Models;
using GestaoEstudioTatuagem.Helpers;
using System.Net.Mail;

namespace GestaoEstudioTatuagem.ViewModels
{
    public partial class CadastroClienteViewModel : ObservableObject
    {
        [ObservableProperty]
        private string nome;

        [ObservableProperty]
        private string email;

        [ObservableProperty]
        private string senha;

        [ObservableProperty]
        private bool isRegistering = false;

        [RelayCommand]
        private async Task CadastrarCliente()
        {
            if (string.IsNullOrWhiteSpace(Nome) || Nome.Trim().Length < 3)
            {
                await Shell.Current.DisplayAlert("Erro", "Informe um nome com pelo menos 3 caracteres.", "OK");
                return;
            }

            if (string.IsNullOrWhiteSpace(Email) || !IsValidEmail(Email.Trim()))
            {
                await Shell.Current.DisplayAlert("Erro", "Informe um e-mail válido.", "OK");
                return;
            }

            if (string.IsNullOrWhiteSpace(Senha) || Senha.Trim().Length < 6)
            {
                await Shell.Current.DisplayAlert("Erro", "A senha deve ter no mínimo 6 caracteres.", "OK");
                return;
            }

            try
            {
                IsRegistering = true;

                var existente = await App.Db.GetUsuarioByEmailAsync(Email.Trim());
                if (existente != null)
                {
                    await Shell.Current.DisplayAlert("Erro", "Já existe um usuário com esse e-mail.", "OK");
                    return;
                }

                var novoUsuario = new Usuario
                {
                    Nome = Nome.Trim(),
                    Email = Email.Trim(),
                    Login = Email.Trim(),
                    SenhaHash = PasswordHelper.HashPassword(Senha.Trim()),
                    Permissoes = new List<string> { "Cliente" }
                };

                await App.Db.SaveUsuarioAsync(novoUsuario);

                await Shell.Current.DisplayAlert("Sucesso", "Cliente cadastrado com sucesso!", "OK");
                await Shell.Current.GoToAsync("//LoginCliente");
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Erro", $"Erro ao cadastrar: {ex.Message}", "OK");
            }
            finally
            {
                IsRegistering = false;
            }
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}