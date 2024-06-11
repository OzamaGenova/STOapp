using STO.ViewModel;
using System.Windows;

namespace STO.View
{
    /// <summary>
    /// Логика взаимодействия для AddNewCarWindow.xaml
    /// </summary>
    public partial class AddNewCarWindow : Window
    {
        public AddNewCarWindow()
        {
            InitializeComponent();
            DataContext = new DataManageVM();
        }
    }
}
