using GestaoEstudioTatuagem.Views;

namespace GestaoEstudioTatuagem
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            // Registro de rotas para navegação programática
            Routing.RegisterRoute(nameof(DetalhesDoTatuador), typeof(DetalhesDoTatuador));
            Routing.RegisterRoute(nameof(DetalhesDoCliente), typeof(DetalhesDoCliente));
        }
    }
}
