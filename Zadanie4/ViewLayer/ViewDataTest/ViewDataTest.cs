using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ViewData.ViewModel;

namespace ViewDataTest
{
    [TestClass]
    public class ViewDataTest
    {

        [TestMethod]
        public void AddCategoryTest()
        {
            IViewModelHelper viewModelHelper = new ViewModelHelperFake();
            MainViewModel viewModel = new MainViewModel();
            viewModel.ViewModelHelper = viewModelHelper;
            viewModel.Name = null;
            viewModel.AddCategoryCommand.Execute(null);
            Assert.AreEqual(4, viewModel.DataLayer.GetAllProductCategories().ToList().Count);

        }

        [TestMethod]
        public void RemoveCategoryTest()
        {
            IViewModelHelper viewModelHelper = new ViewModelHelperFake();
            MainViewModel viewModel = new MainViewModel();
            viewModel.ViewModelHelper = viewModelHelper;
            viewModel.RemoveCategoryCommand.Execute(null);
            Assert.AreEqual(4, viewModel.DataLayer.GetAllProductCategories().ToList().Count);
        }

        [TestMethod]
        public void UpdateCategoryTest()
        {
            IViewModelHelper viewModelHelper = new ViewModelHelperFake();
            MainViewModel viewModel = new MainViewModel();
            viewModel.ViewModelHelper = viewModelHelper;
            viewModel.Name = "Test";
            viewModel.ID = 1;
            viewModel.UpdateCategoryCommand.Execute(null);
            Assert.IsNull(viewModel.DataLayer.GetProductCategoryByName("Test"));
        }

        [TestMethod]
        public void DataLayerTestMethod()
        {
            MainViewModel viewModel = new MainViewModel();
            Assert.IsNotNull(viewModel.DataLayer);
        }


        [TestMethod]
        public void ProductCategoriesTest()
        {
            MainViewModel viewModel = new MainViewModel();
            viewModel.FetchDataCommand.Execute(null);
            Assert.AreEqual(4, viewModel.ProductCategories.Count);
        }

    }
}
