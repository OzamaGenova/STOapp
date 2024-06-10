using STO.Models;
using STO.View;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace STO.ViewModel
{
    public class DataManageVM : INotifyPropertyChanged
    {
        #region Получить все модели
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
        #endregion

        //свойства для услуг
        public static string? Services_Title { get;set; }
        public static double Services_Cost { get; set; }
        public static int Services_TimeOfExecution { get; set; }

        #region COMMANDS TO ADD
        private RelayCommand addNewServices;
        public RelayCommand AddNewServices
        {
            get
            {
                return addNewServices ?? new RelayCommand(obj =>
                {
                    Window wnd = obj as Window;
                    string resultStr = "";
                    if(Services_Title == null)
                    {
                        SetRedBlockControl(wnd,"TitleBlock");
                    }
                    if(Services_Cost == 0) 
                    {
                        SetRedBlockControl(wnd,"CostBlock");
                    }
                    if(Services_TimeOfExecution == 0)
                    {
                        SetRedBlockControl(wnd, "TimeBlock");
                    }
                    else
                    {
                        resultStr = DataWorker.CreateServices(Services_Title,Services_Cost,Services_TimeOfExecution);
                        UpdateAllDataView();
                        ShowMessageToUser(resultStr);
                        SetNullValuesToProreties();
                        wnd.Close();
                    }
                   
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
        #region UPDATE VIEWS
        private void UpdateAllDataView()
        {
            UpdateAllServicesView();
        }
        private void UpdateAllServicesView()
        {
            AllServices = DataWorker.GetAllServices();
            MainWindow.AllServicesView.ItemsSource = null;
            MainWindow.AllServicesView.Items.Clear();
            MainWindow.AllServicesView.ItemsSource = AllServices;
            MainWindow.AllServicesView.Items.Refresh();
        }
        #endregion
        private void SetNullValuesToProreties()
        {
            //для услуги
            Services_Title = null;
            Services_Cost = 0;
            Services_TimeOfExecution = 0;
        }
        private void SetRedBlockControl(Window wnd, string blockName)
        {
            Control block = wnd.FindName(blockName) as Control;
            block.BorderBrush = Brushes.Red;
        }
        private void ShowMessageToUser(string message)
        {
            MessageView messageView = new MessageView(message);
            SetCentralPositionAndOpen(messageView);
        }

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

