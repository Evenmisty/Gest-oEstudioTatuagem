using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;

namespace GestaoEstudioTatuagem.Views
{
    public partial class TelaDeLogin : ContentPage
    {
        public TelaDeLogin()
        {
            InitializeComponent();
        }

        // Quando o ponteiro entra no texto, altera o cursor para "mão"
        private void OnPointerEntered(object sender, EventArgs e)
        {
            var label = sender as Label;
            if (label != null)
            {
                // Adiciona um efeito de "cursor de mão"
                label.TextColor = Color.FromArgb("#a12330");
            }
        }

        // Quando o ponteiro sai, reverte a cor ou o efeito
        private void OnPointerExited(object sender, EventArgs e)
        {
            var label = sender as Label;
            if (label != null)
            {
                label.TextColor = Color.FromArgb("#ccc");  // Reverte para a cor original
            }
        }
    }
}
