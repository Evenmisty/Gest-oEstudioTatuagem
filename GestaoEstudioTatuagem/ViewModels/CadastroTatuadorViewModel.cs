using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GestaoEstudioTatuagem.Models;
using GestaoEstudioTatuagem.Helpers;


    namespace GestaoEstudioTatuagem.ViewModels
    {
        public partial class CadastroTatuadorViewModel : ObservableObject
        {
            [ObservableProperty]
            private string nome;

            [ObservableProperty]
            private string email;

            [ObservableProperty]
            private string senha;

            [ObservableProperty]
            private string cnpj;

            [ObservableProperty]
            private string especialidade;

            [ObservableProperty]
            private string endereco;

            [ObservableProperty]
            private string telefone;

            [ObservableProperty]
            private string instagram;

            [ObservableProperty]
            private string descricao;

            [ObservableProperty]
            private bool isRegistering = false;

            [RelayCommand]
            private async Task CadastrarTatuador()
            {
                if (string.IsNullOrWhiteSpace(Nome) || string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Senha))
                {
                    await Shell.Current.DisplayAlert("Erro", "Todos os campos são obrigatórios.", "OK");
                    return;
                }

                try
                {
                    IsRegistering = true;

                    // Verifica se já existe o usuário com o email
                    var existente = await App.Db.GetUsuarioByEmailAsync(Email.Trim());
                    if (existente != null)
                    {
                        await Shell.Current.DisplayAlert("Erro", "Já existe um tatuador com esse e-mail.", "OK");
                        return;
                    }

                    // Criar objeto Usuario
                    var novoUsuario = new Usuario
                    {
                        Nome = Nome.Trim(),
                        Email = Email.Trim(),
                        Login = Email.Trim(),
                        SenhaHash = PasswordHelper.HashPassword(Senha.Trim()),
                        Permissoes = new List<string> { "Tatuador" }
                    };

                    await App.Db.SaveUsuarioAsync(novoUsuario);

                    var novoTatuador = new Tatuadores
                    {
                        Nome = Nome.Trim(),
                        Especialidade = Especialidade?.Trim() ?? "",
                    };

                    await App.Db.InsertTatuador(novoTatuador);

                    await Shell.Current.DisplayAlert("Sucesso", "Tatuador cadastrado com sucesso!", "OK");
                    await Shell.Current.GoToAsync("//LoginTatuador");
                }
                catch (Exception ex)
                {
                    await Shell.Current.DisplayAlert("Erro", $"Falha ao cadastrar: {ex.Message}", "OK");
                }
                finally
                {
                    IsRegistering = false;
                }
            }
        }
    }
