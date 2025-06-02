namespace GestaoEstudioTatuagem.Views;

public partial class Home : ContentPage
{
    public Home()
    {
        InitializeComponent();
    }
    private async void OnClienteClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//LoginCliente");
    }

    private async void OnTatuadorClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//LoginTatuador");
    }

}
