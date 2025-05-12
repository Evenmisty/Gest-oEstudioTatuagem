using GestaoEstudioTatuagem.ViewModels;

namespace GestaoEstudioTatuagem.Views
{
    public partial class Dashboard : ContentPage
    {
        public Dashboard()
        {
            InitializeComponent();
            BindingContext = new DashboardViewModel();
        }
    }
}
