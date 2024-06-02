using CommunityToolkit.Mvvm.Input;
using Radiologi___Frontend___Maui.Models;
using Radiologi___Frontend___Maui.Services;
using Radiologi___Frontend___Maui.ViewModel;

namespace Radiologi___Frontend___Maui.ViewModel
{
    public class CreateTestViewModel
    {
        TestsService service;

        public List<Question> questions = new List<Question>();

        public CreateTestViewModel(IServiceProvider serviceProvider)
        {
            service = serviceProvider.GetService<TestsService>();
        }
    }
}
