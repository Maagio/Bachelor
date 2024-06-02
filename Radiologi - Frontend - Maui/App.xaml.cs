using Radiologi___Frontend___Maui.Pages;
using Radiologi___Frontend___Maui.Services;
using Radiologi___Frontend___Maui.ViewModel;

namespace Radiologi___Frontend___Maui;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
		
        MainPage = new AppShell();
    }
}
