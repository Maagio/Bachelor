using Radiologi___Frontend___Maui.Models;
using Radiologi___Frontend___Maui.Services;
using Radiologi___Frontend___Maui.ViewModel;
using static System.Net.Mime.MediaTypeNames;

namespace Radiologi___Frontend___Maui.Pages;

public partial class TakeTestPage : ContentPage
{
    //TestsService testsService = new TestsService();
    private TakeTestViewModel viewModel;
    public TakeTestPage(TakeTestViewModel vm)
    {
        InitializeComponent();
        viewModel = vm;
        BindingContext = vm;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        await viewModel.WaitForDataLoadedAsync();

        var testLayout = new StackLayout();
        int questionIndex = 0;
        foreach (Question question in viewModel.test.Questions)
        {
            var questionNumber = new Label
            {
                Text = question.Label
            };

            var strQuestion = new Label
            {
                Text = question.Text
            };

            testLayout.Children.Add(questionNumber);
            testLayout.Children.Add(strQuestion);
            if (question.MultipleChoiceOptions.Count == 0)
            {
                var answerEntry = new Entry
                {
                    Placeholder = "Svar her"
                };
                answerEntry.SetBinding(Entry.TextProperty, new Binding($"answers[{questionIndex}]", source: viewModel));
                testLayout.Children.Add(answerEntry);
            }
            else
            {
                var optionsPicker = new Picker
                {
                    ItemsSource = question.MultipleChoiceOptions
                };
                string temp = "";
                if (optionsPicker.SelectedItem != null)
                {
                    temp = optionsPicker.SelectedItem.ToString();
                }
                var entry = new Entry
                {
                    IsVisible = false,
                    Text = temp
                };
                optionsPicker.SetBinding(Picker.SelectedItemProperty, new Binding($"answers[{questionIndex}]", source: viewModel));
                testLayout.Children.Add(optionsPicker);
                testLayout.Children.Add(entry);
            }
            questionIndex++;
        }
        TestStackLayout.Children.Add(testLayout);
    }
}