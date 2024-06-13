using Radiologi___Frontend___Maui.ViewModel;

namespace Radiologi___Frontend___Maui.Pages;

public partial class RankingsPage : ContentPage
{
	public RankingsPage(RankingsViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}