using STO.Models;
using STO.View;
using System.ComponentModel;
using System.Windows;

namespace STO.ViewModel
{
    public class DataManageVM : INotifyPropertyChanged
    {
        //Все услуги
        private List<Services> allServices = DataWorker.GetAllServices();
        public List<Services> AllServices
        {
            get { return allServices; }
            set
            {
                allServices = value;
                NotifyPropertyChanged("AllServices");
            }
        }
        //все работники
        private List<Worker> allWorkers = DataWorker.GetAllWorkers();
        public List<Worker> AllWorkers
        {
            get { return allWorkers; }
            set
            {
                allWorkers = value;
                NotifyPropertyChanged("AllWorkers");
            }
        }
        //все клиенты
        private List<Client> allClients = DataWorker.GetAllClients();
        public List<Client> AllClients
        {
            get { return allClients; }
            set
            {
                allClients = value;
                NotifyPropertyChanged("AllClient");
            }
        }
        //все заказы
        private List<Order> allOrders = DataWorker.GetAllOrders();
        public List<Order> AllOrders
        {
            get { return allOrders; }
            set
            {
                allOrders = value;
                NotifyPropertyChanged("AllOrders");
            }
        }
        //все проблемы
        private List<Problems> allProblems = DataWorker.GetAllProblems();
        public List<Problems> AllProblems
        {
            get { return allProblems; }
            set
            {
                allProblems = value;
                NotifyPropertyChanged("AllProblems");
            }
        }
        //все машины
        private List<Cars> allCars = DataWorker.GetAllCars();
        public List<Cars> AllCars
        {
            get { return allCars; }
            set
            {
                allCars = value;
                NotifyPropertyChanged("AllCars");
            }
        }

        #region COMMANDS TO ADD
        private RelayCommand addNewServices;
        public RelayCommand AddNewServices
        {
            get
            {
                return addNewServices ?? new RelayCommand(obj =>
                {
                    string resultStr = "";
                    resultStr = DataWorker.CreateServices();
                });
            }
        }
        #endregion

        #region COMMANDS TO OPEN

        private RelayCommand openNewServicesWind;
        public RelayCommand OpenNewServicesWind
        {
            get
            {
                return openNewServicesWind ?? new RelayCommand(obj =>
                {
                    OpenNewSevicesWindowMethod();
                });
            }
        }

        private RelayCommand openNewWorkersWind;
        public RelayCommand OpenNewWorkersWind
        {
            get
            {
                return openNewWorkersWind ?? new RelayCommand(obj =>
                {
                    OpenNewWorkersWindowMethod();
                });
            }
        }

        private RelayCommand openNewCarsWind;
        public RelayCommand OpenAddCarsWind
        {
            get
            {
                return openNewCarsWind ?? new RelayCommand(obj =>
                {
                   OpenNewCarsWindowMethod();
                });
            }
        }

        private RelayCommand openNewClientWind;
        public RelayCommand OpenNewClientWind
        {
            get
            {
                return openNewClientWind ?? new RelayCommand(obj =>
                {
                    OpenNewClientWindowMethod();
                });
            }
        }

        private RelayCommand openNewOrdersWind;
        public RelayCommand OpenNewOrdersWind
        {
            get
            {
                return openNewOrdersWind ?? new RelayCommand(obj =>
                {
                    OpenNewOrdersWindowMethod();
                });
            }
        }

        private RelayCommand openNewProblemsWind;
        public RelayCommand OpenNewProblemsWind
        {
            get
            {
                return openNewProblemsWind ?? new RelayCommand(obj =>
                {
                    OpenNewProblemsWindowMethod();
                });
            }
        }
        #endregion

        #region METHODS TO OPEN WINDOW
        //методы открытия окон
        private void OpenNewSevicesWindowMethod()
        {
            AddNewServicesWindow newServices = new AddNewServicesWindow();
            SetCentralPositionAndOpen(newServices);
        }
        private void OpenNewCarsWindowMethod()
        {
            AddNewCarWindow newCars = new AddNewCarWindow();
            SetCentralPositionAndOpen(newCars);
        }
        private void OpenNewWorkersWindowMethod()
        {
            AddNewWorkerWindow newWorkers = new AddNewWorkerWindow();
            SetCentralPositionAndOpen(newWorkers);
        }
        private void OpenNewClientWindowMethod()
        {
            AddNewClientWindow newClient = new AddNewClientWindow();
            SetCentralPositionAndOpen(newClient);
        }
        private void OpenNewOrdersWindowMethod()
        {
            AddNewOrderWindow newOrder = new AddNewOrderWindow();
            SetCentralPositionAndOpen(newOrder);
        }
        private void OpenNewProblemsWindowMethod()
        {
            AddNewProblemWindow newProblems = new AddNewProblemWindow();
            SetCentralPositionAndOpen(newProblems);
        }

        //методы окна редактирования
        private void OpenEditSevicesWindowMethod()
        {
           EditServicesWindow EditServices = new EditServicesWindow();
            SetCentralPositionAndOpen(EditServices);
        }
        private void OpenEditCarsWindowMethod()
        {
            EditCarWindow newCars = new EditCarWindow();
            SetCentralPositionAndOpen(newCars);
        }
        private void OpenEditWorkersWindowMethod()
        {
            EditWorkerWindow EditWorkers = new EditWorkerWindow();
            SetCentralPositionAndOpen(EditWorkers);
        }
        private void OpenEditClientWindowMethod()
        {
            EditClientWindow EditClient = new EditClientWindow();
            SetCentralPositionAndOpen(EditClient);
        }
        private void OpenEditOrdersWindow()
        {
            EditOrderWindow EditOrder = new EditOrderWindow();
            SetCentralPositionAndOpen(EditOrder);
        }
        private void OpenEditProblemsWindowMethod()
        {
            EditProblemWindow EditProblems = new EditProblemWindow();
            SetCentralPositionAndOpen(EditProblems);
        }

        private void SetCentralPositionAndOpen(Window window)
        {
            window.Owner = Application.Current.MainWindow;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            window.ShowDialog();
        }
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}

