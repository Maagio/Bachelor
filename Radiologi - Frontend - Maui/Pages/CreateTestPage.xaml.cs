using CommunityToolkit.Mvvm.Input;
using Radiologi___Frontend___Maui.Models;
using Radiologi___Frontend___Maui.Services;
using Radiologi___Frontend___Maui.ViewModel;

namespace Radiologi___Frontend___Maui.Pages;

public partial class CreateTestPage : ContentPage
{
    TestsService service = new TestsService();

	private int questionCount = 0;
	private int maxQuestions = 20;

    public List<Question> questions = new List<Question>();
	public CreateTestPage(CreateTestViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
		QuestionTypePicker.SelectedIndex = 0;

        //service = testsService ?? throw new ArgumentNullException(nameof(testsService), "TestsService cannot be null.");
    }

    private void OnAddQuestionClicked(object sender, EventArgs e)
    {
        if (questionCount >= maxQuestions)
        {
            DisplayAlert("Limit Reached", "You cannot add more than 20 questions.", "OK");
            return;
        }

        var selectedType = QuestionTypePicker.SelectedItem.ToString();
        var question = new Question
        {
            Label = $"Question {questionCount + 1}",
            Text = "",
            Type = selectedType == "Text" ? QuestionType.Text : QuestionType.MultipleChoice
        };

        AddQuestionToLayout(question);
        questionCount++;
    }

    private void AddQuestionToLayout(Question question)
    {
        var questionLayout = new StackLayout
        {
            Padding = new Thickness(5)
        };

        var questionLabel = new Label
        {
            Text = question.Label
        };

        questionLayout.Children.Add(questionLabel);

        if (question.Type == QuestionType.Text)
        {
            var questionEntry = new Entry { Placeholder = "Indtast spørgmsål her" };
            var answerEntry = new Entry { Placeholder = "Indtast det korrekte svar her" };

            questionLayout.Children.Add(questionEntry);
            questionLayout.Children.Add(answerEntry);
        }
        else if (question.Type == QuestionType.MultipleChoice)
        {
            var questionEntry = new Entry { Placeholder = "Indtast spørgmsål her" };
            var answerEntry = new Entry { Placeholder = "Indtast det korrekte svar" };
            questionLayout.Children.Add(questionEntry);
            questionLayout.Children.Add(answerEntry);

            var addOption = new Button();
            addOption.Text = "Opret valgmulighed";
            addOption.Clicked += (sender, e) => AddOption(sender,e,questionLayout);

            questionLayout.Children.Add(addOption);
        }

        QuestionsStackLayout.Children.Insert(QuestionsStackLayout.Children.Count - 1, questionLayout);
    }
    private void AddOption(object sender, EventArgs e, StackLayout questionLayout)
    {
        var optionEntry = new Entry { Placeholder = "Indtast valgmulighed" };
        questionLayout.Children.Add(optionEntry);
    }

    public void SaveQuestionsClicked(object sender, EventArgs e)
    {
        SaveQuestions();
    }

    public void SaveQuestions()
    {
        int childCounter = 0;
        questions.Clear();
        foreach (var child in QuestionsStackLayout.Children)
        {
            if (child is StackLayout questionLayout)
            {
                var question = new Question();
                var entry = questionLayout.Children.OfType<Entry>().ToList();
                if (entry != null && entry.Count > 1)
                {
                    question.Label = "Spørgsmål " + childCounter;
                    question.Text = entry[0].Text;
                    question.Answer = entry[1].Text;

                    if (entry.Count > 2)
                    {
                        for (int i = 2; i < entry.Count; i++)
                        {
                            question.MultipleChoiceOptions.Add(entry[i].Text);
                        }
                    }

                    questions.Add(question);
                    
                }
            }
            childCounter++;
        }
    }
    public void SubmitQuestions(object sender, EventArgs e)
    {
        SaveQuestions();
        CreateTest();
    }

    [RelayCommand]
    async Task CreateTest()
    {
        Questionare questionare = new Questionare
        {
            Id = "",
            Name = "",
            Questions = questions,
            TeacherId = "663a183c926caa98c9d55cb4",
            ClassId = "6631e6cb710202d87aa6dee4"
        };

        string response = await service.CreateTest(questionare);

        if (response == "OK")
            await Shell.Current.GoToAsync("..");
        else
            Console.WriteLine("There was an error, please try again");
    }
}