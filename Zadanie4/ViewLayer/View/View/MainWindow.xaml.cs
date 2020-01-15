using System;
using System.Windows;
using ViewData.ViewModel;

namespace View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            MainViewModel _vm = (MainViewModel)DataContext;
            //_vm.MessageBoxShowDelegate = text => MessageBox.Show(text, "Button interaction", MessageBoxButton.OK, MessageBoxImage.Information);
            _vm.ViewModelHelper = new ViewModelHelper();

            // base.OnInitialized(e);
            //MainViewModel _vm = (MainViewModel)DataContext;
            //_vm.ChildWindow = new Lazy<IWindow>(() => new TreeViewMainWindow());
        }

    }
}
