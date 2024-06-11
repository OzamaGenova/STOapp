using STO.Models;
using STO.View;
using System.ComponentModel;
using System.Net.NetworkInformation;
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
        public string? Services_Title { get;set; }
        public double Services_Cost { get; set; }
        public int Services_TimeOfExecution { get; set; }

        //свойства для машины
        public string? Make { get; set; }
        public string? Model { get; set; }
        public string? CarVin { get; set; }
        public int Year { get; set; }
        public string? Color { get; set; }

        //свойства для клиента
        public string Name_Client { get; set; }
        public Cars Car_Client { get; set; }

        //свойства для заказа
        public Client? Client { get; set; }
        public List<Cars>? Cars { get;set;}
        public List<Problems>? Problems { get; set; }
        public List<Services>? Services { get; set; }
        public List<Worker>? Workers { get; set; }

        //свойства для проблем
        public string? Title { get; set; }
        public string? Description { get; set; }
        public double Cost { get; set; }

        //свойства для работника
        public string? Name_Worker { get; set; }
        public decimal Salary { get; set; }

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
                    if(Services_Title == null || Services_Title.Replace(" ","").Length == 0)
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
                        resultStr = DataWorker.CreateServices(Services_Title, Services_Cost, Services_TimeOfExecution);
                        UpdateAllDataView();
                        ShowMessageToUser(resultStr);
                        SetNullValuesToProreties();
                        wnd.Close();
                    }
                   
                });
            }
        }
        private RelayCommand addNewCars;
        public RelayCommand AddNewCars
        {
            get
            {
                return addNewCars ?? new RelayCommand(obj => 
                {
                    Window wnd = obj as Window;
                    string resultStr = "";
                    if (Make == null || Make.Replace(" ", "").Length == 0)
                    {
                        SetRedBlockControl(wnd, "MakeBlock");
                    }
                    if(Model == null || Model.Replace(" ", "").Length == 0)
                    {
                        SetRedBlockControl(wnd, "ModelBlock");
                    }
                    if(CarVin == null)
                    {
                        SetRedBlockControl(wnd, "CarVinBlock");
                    }
                    if(Year == 0)
                    {
                        SetRedBlockControl(wnd, "YearBlock");
                    }
                    if(Color == null || Color.Replace(" ", "").Length == 0)
                    {
                        SetRedBlockControl(wnd, "ColorBlock");
                    }
                    else
                    {
                        resultStr = DataWorker.CreateCars(Make,Model,CarVin, Year, Color);
                        UpdateAllDataView();
                        ShowMessageToUser(resultStr);
                        SetNullValuesToProreties();
                        wnd.Close();
                    }
                });
            }
        }
        private RelayCommand addNewClient;
        public RelayCommand AddNewClient
        {
            get
            {
                return addNewCars ?? new RelayCommand(obj =>
                {
                    Window wnd = obj as Window;
                    string resultStr = "";
                    if(Name_Client == null)
                    {
                        SetRedBlockControl(wnd, "NameBlock");
                    }
                    if (Car_Client == null)
                    {
                        MessageBox.Show("Укажите Машину!");
                    }
                    else
                    {
                        resultStr = DataWorker.CreateClient(Name_Client, Car_Client);
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
            UpdateAllCarsView();
            UpdateAllClientsView();
            UpdateAllOrdersView();
            UpdateAllProblemsView();
            UpdateAllWorkersView();
        }
        private void UpdateAllServicesView()
        {
            AllServices = DataWorker.GetAllServices();
            MainWindow.AllServicesView.ItemsSource = null;
            MainWindow.AllServicesView.Items.Clear();
            MainWindow.AllServicesView.ItemsSource = AllServices;
            MainWindow.AllServicesView.Items.Refresh();
        }
        private void UpdateAllCarsView()
        {
            AllCars = DataWorker.GetAllCars();
            MainWindow.AllCarsView.ItemsSource = null;
            MainWindow.AllCarsView.Items.Clear();
            MainWindow.AllCarsView.ItemsSource = AllCars;
            MainWindow.AllCarsView.Items.Refresh();
        }
        private void UpdateAllClientsView()
        {
            AllClients = DataWorker.GetAllClients();
            MainWindow.AllClientView.ItemsSource = null;
            MainWindow.AllClientView.Items.Clear();
            MainWindow.AllClientView.ItemsSource = AllClients;
            MainWindow.AllClientView.Items.Refresh();
        }
        private void UpdateAllOrdersView()
        {
            AllOrders = DataWorker.GetAllOrders();
            MainWindow.AllOrdersView.ItemsSource = null;
            MainWindow.AllOrdersView.Items.Clear();
            MainWindow.AllOrdersView.ItemsSource = AllOrders;
            MainWindow.AllOrdersView.Items.Refresh();
        }
        private void UpdateAllProblemsView()
        {
            AllProblems = DataWorker.GetAllProblems();
            MainWindow.AllProblemsView.ItemsSource = null;
            MainWindow.AllProblemsView.Items.Clear();
            MainWindow.AllProblemsView.ItemsSource = AllProblems;
            MainWindow.AllProblemsView.Items.Refresh();
        }
        private void UpdateAllWorkersView()
        {
            AllWorkers = DataWorker.GetAllWorkers();
            MainWindow.AllWorkersView.ItemsSource = null;
            MainWindow.AllWorkersView.Items.Clear();
            MainWindow.AllWorkersView.ItemsSource = AllWorkers;
            MainWindow.AllWorkersView.Items.Refresh();
        }
        #endregion
        private void SetNullValuesToProreties()
        {
            //для услуги
            Services_Title = null;
            Services_Cost = 0;
            Services_TimeOfExecution = 0;

            //для машины
            Make = null;
            Model = null;
            CarVin = null;
            Year = 0;
            Color = null;

            //для клиента
            Car_Client = null;
            Name_Client = null;

            //для заказа
            Client = null;
            Problems = null;
            Services = null;
            Workers = null;

            //для проблемы
            Title = null;
            Description = null;
            Cost = 0;

            //для работника
            Name_Worker = null;
            Salary = 0;
        }
        private void SetRedBlockControl(Window wnd, string blockName)
        {
            Control? block = wnd.FindName(blockName) as Control;
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