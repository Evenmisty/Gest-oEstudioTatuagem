using System.Collections.ObjectModel;

namespace GestaoEstudioTatuagem.ViewModels
{
    public class EscolherTatuadorViewModel
    {
        public ObservableCollection<object> ListaTatuadores { get; set; }

        public EscolherTatuadorViewModel()
        {
            ListaTatuadores = new ObservableCollection<object>();
        }
    }
}
