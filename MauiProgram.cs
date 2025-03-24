using DotNet.Meteor.HotReload.Plugin;
using FileReadAndWrite.Service;
using Microsoft.Extensions.Logging;

namespace FileReadAndWrite;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
		#if DEBUG
			.EnableHotReload()
		#endif
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif
		builder.Services.AddSingleton<FileService>();
		return builder.Build();
	}
}
