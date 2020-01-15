using System;
using DataLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ViewData.ViewModel;
using System.Linq;

namespace ViewDataTest
{
    [TestClass]
    public class ViewDataTest
    {

        [TestMethod]
        public void AddCategoryTest()
        {
            IViewModelHelper viewModelHelper = new ViewModelHelperFake();
            MainViewModel viewModel = new MainViewModel(viewModelHelper);
            viewModel.AddCategoryCommand.Execute(null);
            Assert.AreEqual(5, viewModel.DataLayer.GetAllProductCategories().ToList().Count);

        }

        [TestMethod]
        public void RemoveCategoryTest()
        {
            IViewModelHelper viewModelHelper = new ViewModelHelperFake();
            MainViewModel viewModel = new MainViewModel(viewModelHelper);
            viewModel.RemoveCategoryCommand.Execute(null);
            Assert.AreEqual(3, viewModel.DataLayer.GetAllProductCategories().ToList().Count);
        }

        [TestMethod]
        public void UpdateCategoryTest()
        {

        }
    }
}
