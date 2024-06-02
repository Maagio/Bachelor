using Radiologi___Frontend___Maui.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radiologi___Frontend___Maui.ViewModel
{
    public partial class RankingsViewModel
    {
        ClassService service;
        public RankingsViewModel(IServiceProvider serviceProvider)
        {
            service = serviceProvider.GetService<ClassService>();
        }
    }
}
