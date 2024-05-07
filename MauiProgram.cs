using Microsoft.Extensions.Logging;

namespace SCoelloS5
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
            string dbPatc = FileAccessHelper.GetLocalFilePath("dbPersona.db3");
            builder.Services.AddSingleton<PersonRepository>(s=>ActivatorUtilities.CreateInstance<PersonRepository>(s,dbPatc));

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
