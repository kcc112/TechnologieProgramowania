using DataLayer.SqlConnection;
using ServiceLayer;
using System;
using System.Collections.ObjectModel;
using ViewData.MVVM;


namespace ViewData.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            FetchDataCommand = new RelayCommand(() => DataLayer = new DataRepository());
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
     
        public RelayCommand FetchDataCommand
        {
            get; private set;
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

        private DataRepository m_DataLayer;
        private ProductCategory m_ProductCategory;
        private ObservableCollection<ProductCategory> m_ProductCategories;

        #region detail
        private String name;
        public String Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        #endregion

    }
}
