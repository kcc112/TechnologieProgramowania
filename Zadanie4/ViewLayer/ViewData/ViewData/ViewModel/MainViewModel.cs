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

        public DataRepository DataLayer
        {
            get { return m_DataLayer; }
            set
            {
                m_DataLayer = value;
                ProductCategories = new ObservableCollection<ProductCategory>(value.GetAllProductCategories());
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

            Task.Run(() =>
            {
                m_DataLayer.AddProductCategory(productCategory);
            });
        }

        public void RemoveCategory()
        {
            Task.Run(() =>
            {
                m_DataLayer.DeleteProductCategory(ID);
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

        private DataRepository m_DataLayer;
        private ProductCategory m_ProductCategory;
        private ObservableCollection<ProductCategory> m_ProductCategories;

        public string Name { get; set; }
        public int ID { get; set; }
    }
}
