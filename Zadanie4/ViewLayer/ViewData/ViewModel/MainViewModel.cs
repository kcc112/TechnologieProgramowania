using DataLayer.SqlConnection;
using ServiceLayer;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using ViewData.MVVM;


namespace ViewData.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            DataLayer = new DataRepository();
            FetchDataCommand = new RelayCommand(() => DataLayer = new DataRepository());
            AddCategoryCommand = new RelayCommand(AddCategory);
            RemoveCategoryCommand= new RelayCommand(RemoveCategory);
        }
       
        public ObservableCollection<ProductCategory> ProductCategories
        {
            get { return m_ProductCategories; }
            set
            {
                m_ProductCategories = value;
                RaisePropertyChanged();
            }
        }

        public ProductCategory ProductCategory
        {
            get
            {
                return m_ProductCategory;
            }
            set
            {
                m_ProductCategory = value;
                RaisePropertyChanged();
            }
        }

        public IDataRepository DataLayer
        {
            get { return m_DataLayer; }
            set
            {
                m_DataLayer = value;

                Task.Run(() =>
                {
                    ProductCategories = new ObservableCollection<ProductCategory>(value.GetAllProductCategories());
                });
            }
        }

        public void AddCategory()
        {
            ProductCategory productCategory = new ProductCategory
            {
                Name = Name,
                ModifiedDate = DateTime.Today,
                rowguid = Guid.NewGuid()
            };

            if (productCategory.Name == null)
            {
                ViewModelHelper.Show("FirstName and Lastname cannot be empty", "Adding new Person error");
            }
            else
            {
                Task.Run(() =>
                {
                    m_DataLayer.AddProductCategory(productCategory);
                });
            }
        }

        public void RemoveCategory()
        {
            Task.Run(() =>
            {
                if (ID == 0)
                {
                    ViewModelHelper.Show("ID cannot be 0", "Adding new Person error");
                }
                else
                {
                    m_DataLayer.DeleteProductCategory(ID);
                }
            });
        }

        public RelayCommand FetchDataCommand
        {
            get; private set;
        }

        public RelayCommand AddCategoryCommand
        {
            get; private set;
        }

        public RelayCommand RemoveCategoryCommand
        {
            get; private set;
        }

        private IDataRepository m_DataLayer;
        private ProductCategory m_ProductCategory;
        private ObservableCollection<ProductCategory> m_ProductCategories;

        public IViewModelHelper ViewModelHelper { get; set; }
        public string Name { get; set; }
        public int ID { get; set; }
    }
}
