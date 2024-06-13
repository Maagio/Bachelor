using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Radiologi___Frontend___Maui.Models;
using Radiologi___Frontend___Maui.Pages;
using Radiologi___Frontend___Maui.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace Radiologi___Frontend___Maui.ViewModel
{
    [QueryProperty("Id", "Id")]
    public partial class TestsOverviewViewModel : ObservableObject, INotifyPropertyChanged
    {
        TestsService testsService;
        UserService userService;
        ClassService classService;
        public ICommand TakeTestCommand { get; }

        public TestsOverviewViewModel(IServiceProvider serviceProvider)
        {
            testsService = serviceProvider.GetService<TestsService>();
            userService = serviceProvider.GetService<UserService>();
            classService = serviceProvider.GetService<ClassService>();

            TakeTestCommand = new RelayCommand(TakeTest);
        }


        [ObservableProperty]
        string id;

        [ObservableProperty]
        public string testId;

        [ObservableProperty]
        List<string> names = new List<string>();

        [ObservableProperty]
        public Class selectedClass;

        private ObservableCollection<Class> _classes = new ObservableCollection<Class>();
        public ObservableCollection<Class> Classes
        {
            get { return _classes; }
            set
            {
                if (_classes != value)
                {
                    _classes = value;
                    OnPropertyChanged(nameof(Classes));
                }
            }
        }

        async partial void OnIdChanged(string value)
        {
            if(!string.IsNullOrEmpty(value))
            {
                List<string> classIds = await GetClassesByUserId(value);
                GetClassesByIds(classIds);
            }
        }

        async Task<List<string>> GetClassesByUserId(string userId)
        {
            var classIds = await userService.GetClassesByIUserd(userId);

            return classIds;
        }

        async Task GetClassesByIds(List<string> classIds)
        {
            List<Class> classesList = await classService.GetClassesByIds(classIds);

            // Convert List<Class> to ObservableCollection<Class>
            ObservableCollection<Class> classesCollection = new ObservableCollection<Class>(classesList);

            // Assign ObservableCollection<Class> to the Classes property
            Classes = classesCollection;
        }

        public async void TakeTest()
        {
            await Shell.Current.GoToAsync($"{nameof(TakeTestPage)}?Id={testId}&UserId={id}");
        }
    }
}
