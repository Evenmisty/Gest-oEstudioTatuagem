namespace GestãoEstudioTatuagem.Views;

public partial class TelaDeLogin : ContentPage
{
	public TelaDeLogin()
	{
		InitializeComponent();
	}
    private async void OnCadastrarClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Cadastrar());
    }
}