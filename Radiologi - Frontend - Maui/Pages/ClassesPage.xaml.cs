using Radiologi___Frontend___Maui.ViewModel;

namespace Radiologi___Frontend___Maui.Pages;

public partial class ClassesPage : ContentPage
{
	public ClassesPage(ClassesViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}