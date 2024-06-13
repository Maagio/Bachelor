using Radiologi___Frontend___Maui.ViewModel;

namespace Radiologi___Frontend___Maui.Pages;

public partial class LoginPage : ContentPage
{
	public LoginPage(LoginViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}

