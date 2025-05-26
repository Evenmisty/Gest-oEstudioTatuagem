using Microsoft.Maui;
using Microsoft.Maui.Hosting;
using Microsoft.UI.Xaml;
using System;

namespace GestaoEstudioTatuagem.WinUI
{
    public partial class App : MauiWinUIApplication
    {
        public App() : base()
        {
            InitializeComponent();
        }

        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
    }
}
