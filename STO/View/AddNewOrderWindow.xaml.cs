using STO.Models;
using STO.ViewModel;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;



namespace STO.View
{
    /// <summary>
    /// Логика взаимодействия для AddNewOrderWindow.xaml
    /// </summary>
    public partial class AddNewOrderWindow : Window
    {
        public AddNewOrderWindow(ObservableCollection<Client> clients, ObservableCollection<Problems> problems, ObservableCollection<Services> services, ObservableCollection<Worker> workers)
        {
            InitializeComponent();

            DataContext = new AddOrderWindowViewModel(clients, problems, services, workers);
        }
        private void AddOrderButton_Click(object sender, RoutedEventArgs e)
        {
            clientComboBox.SelectedItem = null;
            problemComboBox.SelectedItem = null;
            serviceComboBox.SelectedItem = null;
            workerComboBox.SelectedItem = null;
        }
    }

    public class AddOrderWindowViewModel
    {
            public ObservableCollection<Client> Clients { get; }
            public ObservableCollection<Problems> Problems { get; }
            public ObservableCollection<Services> Services { get; }
            public ObservableCollection<Worker> Workers { get; }

            public AddOrderWindowViewModel(ObservableCollection<Client> clients, ObservableCollection<Problems> problems, ObservableCollection<Services> services, ObservableCollection<Worker> workers)
            {
                Clients = clients;
                Problems = problems;
                Services = services;
                Workers = workers;
            }

    }

}
