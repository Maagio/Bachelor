using CommunityToolkit.Mvvm.Input;
using Radiologi___Frontend___Maui.ViewModel;
using Radiologi___Frontend___Maui.Models;
using Radiologi___Frontend___Maui.Services;

namespace Radiologi___Frontend___Maui.Pages;

public partial class TestsOverviewPage : ContentPage
{
    private TestsOverviewViewModel _vm;
    TestsService testsService = new TestsService();
	public TestsOverviewPage(TestsOverviewViewModel vm)
	{
		InitializeComponent();
        _vm = vm;
		BindingContext = vm;
	}

    public void ShowTestsClicked(object sender, EventArgs e)
    {
        ShowTestsOverview();
    }
    public async Task ShowTestsOverview()
    {
        TestsStackLayout.Children.Clear();
        Class tempClass = (Class)ClassPicker.SelectedItem;
        _vm.selectedClass = tempClass;
        List<Questionare> tests = await testsService.GetTestsByClassId(tempClass.Id);

        var testsLayout = new StackLayout();

        foreach (var test in tests)
        {
            var testNameLabel = new Label
            {
                Text = test.Name
            };

            var newButton = new Button
            {
                Text = "Tag test",
            };
            _vm.testId = test.Id;
            newButton.Command = _vm.TakeTestCommand;

            testsLayout.Children.Add(testNameLabel);
            testsLayout.Children.Add(newButton);
        }
        TestsStackLayout.Children.Add(testsLayout);
        
    }
}