namespace GestaoEstudioTatuagem.Views;

public partial class Home : ContentPage
{
    public Home()
    {
        InitializeComponent();
    }
    private async void OnClienteClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new TelaDeCadastro());
    }

    private async void OnTatuadorClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new TelaDeCadastro());
    }

}
