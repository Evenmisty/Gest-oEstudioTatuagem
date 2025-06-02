using GestaoEstudioTatuagem.Helpers;
using System.Globalization;
using Microsoft.Maui.Hosting;

namespace GestaoEstudioTatuagem
{
    public partial class App : Application
    {
        // Removi qualquer duplicidade
        private static readonly object _dbLock = new();
        private static SQLiteDatabaseHelper? _db; // Usando nullable para evitar erros

        public static SQLiteDatabaseHelper Db
        {
            get
            {
                lock (_dbLock)
                {

                        return _db ??= new SQLiteDatabaseHelper(
                            Path.Combine(
                                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                                "banco_sqlite_tatuagens.db3"
                            ));
                }
            }         
        }

        public App()
        {
            InitializeComponent();
            AppDomain.CurrentDomain.UnhandledException += (sender, args) =>
            {
                var ex = (Exception)args.ExceptionObject;
                Console.WriteLine($"Erro Não Tratado: {ex.Message}\n{ex.StackTrace}");
            };

            TaskScheduler.UnobservedTaskException += (sender, args) =>
            {
                Console.WriteLine($"Erro Não Tratado em Tarefa: {args.Exception.Message}\n{args.Exception.StackTrace}");
                args.SetObserved();
            };
        }

        protected override Window CreateWindow(IActivationState activationState)
        {
            try
            {
                return new Window(new AppShell());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao criar a janela principal: {ex.Message}");
                throw;
            }
        }
    }
}
