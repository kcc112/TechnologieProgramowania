using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewData.ViewModel;

namespace ViewDataTest
{
    internal class ViewModelHelperFake : IViewModelHelper
    {
        public void Show(string errorName, string errorMessage) { }
    }
}
