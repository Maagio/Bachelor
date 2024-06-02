using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Radiologi___Frontend___Maui.Pages;
using Radiologi___Frontend___Maui.Services;
using Radiologi___Frontend___Maui.Models;

namespace Radiologi___Frontend___Maui.ViewModel
{
    public partial class SignUpViewModel : ObservableObject
    {
        UserService service;

        public SignUpViewModel(IServiceProvider serviceProvider)
        {
            service = serviceProvider.GetService<UserService>();
        }

        // variables that are data bound to the xaml page
        [ObservableProperty]
        string name;
        [ObservableProperty]
        string password;
        [ObservableProperty]
        string email;
        [ObservableProperty]
        Boolean isTeacher;

        [RelayCommand]
        async Task CreateUser()
        {
            // Converts the value from the checkbox to a 0-1 int
            int _isTeacher = 0;
            if (IsTeacher == true)
                _isTeacher = 1;

            User user = new User
            {
                Id = "",
                Name = Name,
                Password = Password,
                Email = Email,
                IsTeacher = _isTeacher,
                ClassIds = new List<string>()
            };

            string response = await service.CreateUser(user);

            if (response == "OK")
                await Shell.Current.GoToAsync("..");
            else
                Console.WriteLine("There was an error, please try again");
        }
    }
}
