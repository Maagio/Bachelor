using Radiologi___Frontend___Maui.ViewModel;

namespace Radiologi___Frontend___Maui.Pages;

public partial class TeacherHomePage : ContentPage
{
	public TeacherHomePage(TeacherHomeViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}