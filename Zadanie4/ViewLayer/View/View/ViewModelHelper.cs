using System.Windows;
using ViewData.ViewModel;

namespace View
{
    public class ViewModelHelper : IViewModelHelper
    {
        public void Show(string errorName, string errorMessage)
        {
            MessageBox.Show(errorName, errorMessage, MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public void ShowInfo()
        {
            new InfoView().Show();
        }
    }
}
