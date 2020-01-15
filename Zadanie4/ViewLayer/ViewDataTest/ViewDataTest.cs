using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ViewData.ViewModel;

namespace ViewDataTest
{
    [TestClass]
    public class ViewDataTest
    {

        [TestMethod]
        public void DataLayerTestMethod()
        {
            MainViewModel viewModel = new MainViewModel();
            Assert.IsNotNull(viewModel.DataLayer);
        }

        [TestMethod]
        public void RemoveCategoryTestMethod()
        {
            IViewModelHelper viewModelHelper = new ViewModelHelperFake();
            MainViewModel viewModel = new MainViewModel();
            viewModel.ViewModelHelper = viewModelHelper;
            viewModel.RemoveCategoryCommand.Execute(null);
            viewModel.FetchDataCommand.Execute(null);
            Assert.AreEqual(5, viewModel.DataLayer.GetAllProductCategories().ToList().Count);
        }

        [TestMethod]
        public void AddCategoryTestMethod()
        {
            IViewModelHelper viewModelHelper = new ViewModelHelperFake();
            MainViewModel viewModel = new MainViewModel();
            viewModel.ViewModelHelper = viewModelHelper;
            viewModel.AddCategoryCommand.Execute(null);
            viewModel.FetchDataCommand.Execute(null);
            Assert.AreEqual(5, viewModel.DataLayer.GetAllProductCategories().ToList().Count);
        }


        [TestMethod]
        public void ProductCategoriesTest()
        {
            MainViewModel viewModel = new MainViewModel();
            viewModel.FetchDataCommand.Execute(null);
            Assert.AreEqual(5, viewModel.ProductCategories.Count);
        }

        [TestMethod]
        public void UpdateCategoryTestMethod()
        {
            IViewModelHelper viewModelHelper = new ViewModelHelperFake();
            MainViewModel viewModel = new MainViewModel();
            viewModel.ViewModelHelper = viewModelHelper;
            viewModel.UpdateCategoryCommand.Execute(null);
            viewModel.FetchDataCommand.Execute(null);
            Assert.AreEqual(5, viewModel.DataLayer.GetAllProductCategories().ToList().Count);
        }

    }
}
