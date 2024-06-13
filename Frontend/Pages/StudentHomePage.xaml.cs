using Radiologi___Frontend___Maui.Services;
using Radiologi___Frontend___Maui.ViewModel;

namespace Radiologi___Frontend___Maui.Pages;

public partial class StudentHomePage : ContentPage
{
	UserService service;
    StudentHomeViewModel vm;

	public StudentHomePage(StudentHomeViewModel _vm, IServiceProvider serviceProvider)
	{
		InitializeComponent();
        vm = _vm;
		BindingContext = vm;

        service = serviceProvider.GetService<UserService>();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        //vm = await service.GetUserById(vm.Id);
    }
}