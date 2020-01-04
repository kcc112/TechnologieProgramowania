using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ViewData.ViewModel;

namespace ViewDataTest
{
    [TestClass]
    public class ViewDataTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            IViewModelHelper viewModelHelper = new ViewModelHelperFake();
            MainViewModel viewModel = new MainViewModel(viewModelHelper);
        }
    }
}
