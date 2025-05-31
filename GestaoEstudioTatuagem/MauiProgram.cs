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

                fonts.AddFont("DMSans-ExtraLight.ttf", "DMSansExtraLight");
                fonts.AddFont("DMSans_18pt-Light.ttf", "DMSansLight");

                fonts.AddFont("Poppins-Regular.ttf", "PoppinsRegular");
                fonts.AddFont("Poppins-Bold.ttf", "PoppinsBold");
                fonts.AddFont("Poppins-ExtraBold.ttf", "PoppinsExtraBold");
                fonts.AddFont("Poppins-Italic.ttf", "PoppinsItalic");
                fonts.AddFont("Poppins-SemiBold.ttf", "PoppinsSemiBold");

                fonts.AddFont("Questrial-Regular.ttf", "Questrial");
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
