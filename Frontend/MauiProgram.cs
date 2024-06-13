using Microsoft.Extensions.Logging;
using Radiologi___Frontend___Maui.Pages;
using Radiologi___Frontend___Maui.Services;
using Radiologi___Frontend___Maui.ViewModel;

namespace Radiologi___Frontend___Maui;

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

		builder.Services.AddSingleton<LoginPage>();
		builder.Services.AddSingleton<LoginViewModel>();

        builder.Services.AddTransient<SignUpPage>();
        builder.Services.AddTransient<SignUpViewModel>();

        builder.Services.AddSingleton<StudentHomePage>();
        builder.Services.AddSingleton<StudentHomeViewModel>();

        builder.Services.AddSingleton<TeacherHomePage>();
        builder.Services.AddSingleton<TeacherHomeViewModel>();

		builder.Services.AddTransient<ClassesPage>();
		builder.Services.AddTransient<ClassesViewModel>();

        builder.Services.AddSingleton<RankingsPage>();
        builder.Services.AddSingleton<RankingsViewModel>();

        builder.Services.AddSingleton<TestsOverviewPage>();
        builder.Services.AddSingleton<TestsOverviewViewModel>();

        builder.Services.AddTransient<CreateTestPage>();
        builder.Services.AddTransient<CreateTestViewModel>();

        builder.Services.AddTransient<TakeTestPage>();
        builder.Services.AddTransient<TakeTestViewModel>();

        builder.Services.AddSingleton<UserService>();
        builder.Services.AddSingleton<TestsService>();
        builder.Services.AddSingleton<ClassService>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
