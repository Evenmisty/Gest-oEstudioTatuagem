using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using GestaoEstudioTatuagem.Models;
using System;
using System.Threading.Tasks;
using System.Text.Json;
using System.Linq;

namespace GestaoEstudioTatuagem.ViewModels
{
    public partial class UsuarioViewModel : ObservableObject
    {
        // Lista de Usuários
        [ObservableProperty]
        private ObservableCollection<Usuario> usuarios = new ObservableCollection<Usuario>();

        // Propriedades para Novo Usuário / Login
        [ObservableProperty]
        private string login = string.Empty;

        [ObservableProperty]
        private string senha = string.Empty;

        [ObservableProperty]
        private string permissoesJson = "[]";

        [ObservableProperty]
        private bool estaLogado = false;

        // Propriedade para Exibir as Permissões de um Usuário
        [ObservableProperty]
        private string permissoesExibidas = string.Empty;

        // Construtor
        public UsuarioViewModel()
        {
            // Inicializando com alguns usuários para testes (pode ser removido)
            Usuarios = new ObservableCollection<Usuario>
            {
                new Usuario { Login = "admin", SenhaHash = "admin123", PermissoesJson = JsonSerializer.Serialize(new[] { "Admin", "User" }) },
                new Usuario { Login = "user", SenhaHash = "user123", PermissoesJson = JsonSerializer.Serialize(new[] { "User" }) }
            };
        }

        // Comando para Registrar Novo Usuário
        [RelayCommand]
        private async Task RegistrarUsuario()
        {
            if (string.IsNullOrWhiteSpace(Login) || string.IsNullOrWhiteSpace(Senha))
            {
                await Shell.Current.DisplayAlert("Erro", "Preencha o login e a senha.", "OK");
                return;
            }

            if (Usuarios.Any(u => u.Login == Login))
            {
                await Shell.Current.DisplayAlert("Erro", "O usuário já está registrado.", "OK");
                return;
            }

            var novoUsuario = new Usuario
            {
                Login = Login,
                SenhaHash = Senha,
                PermissoesJson = PermissoesJson
            };

            Usuarios.Add(novoUsuario);
            await Shell.Current.DisplayAlert("Sucesso", "Usuário registrado com sucesso!", "OK");
            LimparCampos();
        }

        // Comando para Login do Usuário
        [RelayCommand]
        private async Task FazerLogin()
        {
            if (string.IsNullOrWhiteSpace(Login) || string.IsNullOrWhiteSpace(Senha))
            {
                await Shell.Current.DisplayAlert("Erro", "Preencha o login e a senha.", "OK");
                return;
            }

            var usuario = Usuarios.FirstOrDefault(u => u.Login == Login && u.SenhaHash == Senha);
            if (usuario == null)
            {
                await Shell.Current.DisplayAlert("Erro", "Usuário ou senha incorretos.", "OK");
                return;
            }

            // Usuário autenticado
            EstaLogado = true;
            PermissoesExibidas = string.Join(", ", JsonSerializer.Deserialize<string[]>(usuario.PermissoesJson) ?? new string[0]);
            await Shell.Current.DisplayAlert("Bem-vindo", $"Login realizado com sucesso! Bem-vindo, {Login}.", "OK");
            LimparCampos();
        }

        // Comando para Sair
        [RelayCommand]
        private void Sair()
        {
            EstaLogado = false;
            PermissoesExibidas = string.Empty;
            LimparCampos();
        }

        // Comando para Remover Usuário
        [RelayCommand]
        private async Task RemoverUsuario(Usuario usuario)
        {
            if (usuario == null) return;

            var confirmacao = await Shell.Current.DisplayAlert("Confirmação", "Deseja remover este usuário?", "Sim", "Não");
            if (confirmacao)
            {
                Usuarios.Remove(usuario);
                await Shell.Current.DisplayAlert("Sucesso", "Usuário removido com sucesso.", "OK");
            }
        }

        // Método para Limpar os Campos
        private void LimparCampos()
        {
            Login = string.Empty;
            Senha = string.Empty;
            PermissoesJson = "[]";
        }
    }
}
