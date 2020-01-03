using System.Windows;

namespace ViewData.ViewModel
{
    public class ViewModelHelper : IViewModelHelper
    {
        public void Show(string errorName, string errorMessage)
        {
            MessageBox.Show(errorMessage, errorName, MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }
}
