using STO.Models;
using STO.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        //методы открытия окон
        private void OpenAddSevicesWindowmethod()
        {
            AddNewServicesWindow newServices = new AddNewServicesWindow();
            SetCentralPositionAndOpen(newServices);
        }

        private void SetCentralPositionAndOpen(Window window)
        {
            window.Owner = Application.Current.MainWindow;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            window.ShowDialog();
        }
        //методы окна редактирования
        
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
