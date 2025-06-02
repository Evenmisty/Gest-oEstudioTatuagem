using GestaoEstudioTatuagem.ViewModels;


namespace GestaoEstudioTatuagem.Views;

public partial class LoginTatuador : ContentPage
{
	public LoginTatuador()
	{
		InitializeComponent();
        var vm = new TelaDeLoginViewModel();
        vm.Perfil = "Tatuador";
        BindingContext = vm;
    }
}