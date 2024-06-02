using Radiologi___Frontend___Maui.Pages;

namespace Radiologi___Frontend___Maui;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
        Routing.RegisterRoute(nameof(SignUpPage), typeof(SignUpPage));
		Routing.RegisterRoute(nameof(StudentHomePage), typeof(StudentHomePage));
        Routing.RegisterRoute(nameof(TeacherHomePage), typeof(TeacherHomePage));
        Routing.RegisterRoute(nameof(ClassesPage), typeof(ClassesPage));
        Routing.RegisterRoute(nameof(RankingsPage), typeof(RankingsPage));
        Routing.RegisterRoute(nameof(CreateTestPage), typeof(CreateTestPage));
        Routing.RegisterRoute(nameof(TestsOverviewPage), typeof(TestsOverviewPage));
        Routing.RegisterRoute(nameof(TakeTestPage), typeof(TakeTestPage));
    }
}
