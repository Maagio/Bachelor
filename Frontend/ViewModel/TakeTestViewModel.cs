using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls;
using Radiologi___Frontend___Maui.Models;
using Radiologi___Frontend___Maui.Pages;
using Radiologi___Frontend___Maui.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Radiologi___Frontend___Maui.ViewModel
{
    [QueryProperty("Id", "Id")]
    [QueryProperty("UserId", "UserId")]
    public partial class TakeTestViewModel : ObservableObject, INotifyPropertyChanged
    {
        TestsService testsService;
        private TaskCompletionSource<bool> dataLoadedTaskCompletionSource = new TaskCompletionSource<bool>();
        public ICommand SubmitCommand { get; set; }
        public Dictionary<int, string> answers { get; set; }

        public TakeTestViewModel(IServiceProvider serviceProvider)
        {
            testsService = serviceProvider.GetService<TestsService>();
            answers = new Dictionary<int, string>();
            SubmitCommand = new Command(OnSubmit);
        }

        [ObservableProperty]
        public string id;

        [ObservableProperty]
        public string userId;

        [ObservableProperty]
        public Questionare test;

        partial void OnIdChanged(string value)
        {
            if(!string.IsNullOrEmpty(value))
            {
                GetTestById(value);
            }
        }

        async Task GetTestById(string testId)
        {
            test = await testsService.GetTestByTestId(testId);
            dataLoadedTaskCompletionSource.SetResult(true);
        }
        public Task WaitForDataLoadedAsync() => dataLoadedTaskCompletionSource.Task;

        private async void OnSubmit()
        {
            AnsweredTest answeredTest = new AnsweredTest
            {
                Id = "",
                UserId = userId,
                Score = 4,
                TestId = id
            };
            foreach (var answer in answers)
            {
                int count = (int)answer.Key + 1;
                Question question = new Question
                {
                    Label = count.ToString(),
                    Answer = answer.Value,
                    Text = ""
                };
                answeredTest.Questions.Add(question);
            }
            string response = await testsService.SaveAnswers(answeredTest);
            
            if (response == "OK")
                await Shell.Current.GoToAsync($"{nameof(StudentHomePage)}?Id={userId}");
            else
                Console.WriteLine("There was an error, please try again");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
