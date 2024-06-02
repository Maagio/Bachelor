using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Radiologi___Frontend___Maui.Models;
using Radiologi___Frontend___Maui.Pages;
using Radiologi___Frontend___Maui.Services;

namespace Radiologi___Frontend___Maui.ViewModel
{
    [QueryProperty("Id", "Id")]
    public partial class StudentHomeViewModel : ObservableObject
    {
        UserService service;

        public StudentHomeViewModel(IServiceProvider serviceProvider)
        {
            service = serviceProvider.GetService<UserService>();
        }

        [ObservableProperty]
        string id;

        [ObservableProperty]
        string name;

        partial void OnIdChanged(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                GetUserById(value);
            }
        }

        async Task GetUserById(string userId)
        {
            var user =  await service.GetUserById(userId);
            Name = user.Name;
        }

        [RelayCommand]
        async Task ViewTests()
        {
            await Shell.Current.GoToAsync($"{nameof(TestsOverviewPage)}?Id={Id}");
        }

        [RelayCommand]
        async Task ViewRankings()
        {
            await Shell.Current.GoToAsync(nameof(RankingsPage));
        }
        [RelayCommand]
        async Task Logout()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
