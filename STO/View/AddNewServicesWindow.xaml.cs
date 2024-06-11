using STO.ViewModel;
using System.Windows;

namespace STO.View
{
    /// <summary>
    /// Логика взаимодействия для AddNewServicesWindow.xaml
    /// </summary>
    public partial class AddNewServicesWindow : Window
    {
        public AddNewServicesWindow()
        {
            InitializeComponent();
            DataContext = new DataManageVM();
        }
    }
}
