using STO.ViewModel;
using System.Windows;
using System.Windows.Controls;


namespace STO.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static ListView AllServicesView;
        public static ListView AllCarsView;
        public static ListView AllClientView;
        public static ListView AllOrdersView;
        public static ListView AllProblemsView;
        public static ListView AllWorkersView;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new DataManageVM();
        }
    }
}