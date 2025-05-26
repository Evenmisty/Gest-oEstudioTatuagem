using Microsoft.Extensions.Logging;
using GestaoEstudioTatuagem.Helpers;
using Microsoft.Maui.Hosting;

namespace GestaoEstudioTatuagem
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            // Injetando o SQLiteDatabaseHelper (Injeção de Dependência)
            builder.Services.AddSingleton<SQLiteDatabaseHelper>(provider =>
            {
                string dbPath = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                    "banco_sqlite_tatuagens.db3");

                return new SQLiteDatabaseHelper(dbPath);
            });

#if DEBUG
            builder.Logging.AddDebug();
#else
            builder.Logging.AddConsole();
#endif

            return builder.Build();
        }
    }
}
