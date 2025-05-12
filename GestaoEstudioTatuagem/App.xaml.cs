using Microsoft.Maui.Controls;

namespace GestaoEstudioTatuagem
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override IAppHostBuilder CreateAppHostBuilder() => MauiProgram.CreateMauiApp();
    }
}
