using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Radiologi___Frontend___Maui.Services;
using Radiologi___Frontend___Maui.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radiologi___Frontend___Maui.ViewModel
{
    public partial class TeacherHomeViewModel : ObservableObject
    {
        UserService service;

        public TeacherHomeViewModel(IServiceProvider serviceProvider)
        {
            service = serviceProvider.GetService<UserService>();
        }

        [ObservableProperty]
        string id;

        [RelayCommand]
        async Task ViewClasses()
        {
            await Shell.Current.GoToAsync(nameof(ClassesPage));
        }

        [RelayCommand]
        async Task CreateTest()
        {
            await Shell.Current.GoToAsync(nameof(CreateTestPage));
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
