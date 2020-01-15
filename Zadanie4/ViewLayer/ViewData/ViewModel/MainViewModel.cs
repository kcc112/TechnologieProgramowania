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
            RemoveCategoryCommand = new RelayCommand(RemoveCategory);
            InfoCategoryCommand = new RelayCommand(Info);
            UpdateCategoryCommand = new RelayCommand(UpdateCategory);
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
                ViewModelHelper.Show("Name cannot be empty", "Add");
            }
            else
            {
                Task.Run(() =>
                {
                    m_DataLayer.AddProductCategory(productCategory);
                });
            }
        }

        public void UpdateCategory()
        {
            if (Name == null || ID == 0)
            {
                ViewModelHelper.Show("FirstName and ID cannot be empty", " Update");
            }
            else
            {
                Task.Run(() =>
                {
                    m_DataLayer.UpdateProductCategory(Name, ID);
                });
            }
        }

        public void RemoveCategory()
        {
            Task.Run(() =>
            {
                if (ID == 0)
                {
                    ViewModelHelper.Show("ID cannot be 0", "Remove");
                }
                else
                {
                    m_DataLayer.DeleteProductCategory(ID);
                }
            });
        }

        public void Info()
        {
            Task.Run(() =>
            {
                ProductCategories = new ObservableCollection<ProductCategory>();
                ProductCategories.Add(m_DataLayer.GetProductCategoryById(ID));
               ProductCategory = m_DataLayer.GetProductCategoryById(ID);
            });
            ViewModelHelper.ShowInfo();
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

        public RelayCommand InfoCategoryCommand
        {
            get; private set;
        }

        public RelayCommand UpdateCategoryCommand
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
