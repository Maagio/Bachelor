using Radiologi___Frontend___Maui.Services;

namespace Radiologi___Frontend___Maui.ViewModel
{
    [QueryProperty("Id", "Id")]
    public partial class ClassesViewModel
    {
        ClassService service;
        public ClassesViewModel(IServiceProvider serviceProvider) 
        {
            service = serviceProvider.GetService<ClassService>();
        }
    }
}
