using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Radiologi___Frontend___Maui.Pages;
using Radiologi___Frontend___Maui.Models;
using Radiologi___Frontend___Maui.Services;
using System.Xml.Linq;

namespace Radiologi___Frontend___Maui.ViewModel
{
    public partial class LoginViewModel : ObservableObject
    {
        UserService service;

        public LoginViewModel(IServiceProvider serviceProvider)
        {
            service = serviceProvider.GetService<UserService>();
        }
        [ObservableProperty]
        string email;

        [ObservableProperty]
        string password;

        [RelayCommand]
        async Task Login()
        {
            // Temp user to lookup the actual user in the database.
            User tempUser = new User
            {
                Id = "",
                Name = "",
                Password = Password,
                Email = Email,
                IsTeacher = 0,
                ClassIds = new List<string>()
            };

            User foundUser = await service.Login(tempUser);
            if (foundUser != null)
            {
                if (foundUser.IsTeacher == 1)
                    await Shell.Current.GoToAsync($"{nameof(TeacherHomePage)}?Id={foundUser.Id}");
                else
                    await Shell.Current.GoToAsync($"{nameof(StudentHomePage)}?Id={foundUser.Id}");
            }
            else
                Console.WriteLine("Incorrect info");
        }

        [RelayCommand]
        async Task SignUp()
        {
            await Shell.Current.GoToAsync(nameof(SignUpPage));
        }
    }
}
