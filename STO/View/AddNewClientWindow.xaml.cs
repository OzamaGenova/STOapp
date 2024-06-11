using STO.Models;
using STO.ViewModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
namespace STO.View
{
    /// <summary>
    /// Логика взаимодействия для AddNewClientWindow.xaml
    /// </summary>
    public partial class AddNewClientWindow : Window
    {
        public AddNewClientWindow()
        {
            InitializeComponent();
            DataContext = new DataManageVM();
        }
    }
}
