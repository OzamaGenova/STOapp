using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using STO.Models.Data;

namespace STO.Models
{
    public static class DataWorker
    {
        #region GetAllModels
        //Получить все услуги
        public static List<Services> GetAllServices()
        {
            using(ApplicationContext db = new ApplicationContext())
            {
                 return db.Services.ToList();
            }
        }
        //получить всех клиентов
        public static List<Client> GetAllClients()
        {
            using(ApplicationContext db = new ApplicationContext())
            {
                return db.Client.ToList();;
            }
        }
        //получить все проблемы
        public static List<Problems> GetAllProblems()
        {
            using(ApplicationContext db = new ApplicationContext())
            {
                return db.Problems.ToList();
            }
        }
        //получить всех работников
        public static List<Worker> GetAllWorkers()
        {
            using(ApplicationContext db = new ApplicationContext())
            {
                return db.Worker.ToList();
            }
        }
        //получить все машины
        public static List<Cars> GetAllCars()
        {
            using(ApplicationContext db = new ApplicationContext())
            {
                return db.Cars.ToList();
            }
        }
        //получить все заказы
        public static List<Order> GetAllOrders()
        {
            using(ApplicationContext db = new ApplicationContext())
            {
                return db.Order.ToList();
            }
        }
        #endregion

        #region ServicesModel
        //Создание новой услуги
        public static string CreateServices(string title, double cost, int time)
        {
            string result = "Уже существует!";
            using (ApplicationContext db = new ApplicationContext())
            {
                bool checkIsExist = db.Services.Any(el => el.Services_Title == title);
                if (!checkIsExist)
                {
                    Services newServices = new Services(title, cost, time);
                    db.Services.Add(newServices);
                    db.SaveChanges();
                    result = "Сделано!";
                }
                return result;
            }
        }
        //Удаление услуги
        public static string DeleteServices(Services services)
        {
            string result = "Такой услуги нет";
            using(ApplicationContext db = new ApplicationContext())
            {
                db.Services.Remove(services);
                db.SaveChanges();
                result = "Сделано! Услуга" + services.Services_Title + "удалена";
            }
            return result;
        }
        //Редактирование услуги
        public static string EditServices(Services OldServices, string newName, double newCost, int newTime)
        {
            string result = "Такой услуги нет";
            using( ApplicationContext db = new ApplicationContext())
            {
                Services servicesToUpdate = db.Services.FirstOrDefault(d => d.Id == OldServices.Id);
                if (servicesToUpdate != null)
                {
                    servicesToUpdate.Services_Title = newName;
                    servicesToUpdate.Services_Cost = newCost;
                    servicesToUpdate.Services_TimeOfExecution = newTime;
                    db.Services.Remove(servicesToUpdate);
                    db.SaveChanges();
                    result = "Сделано! Услуга" + servicesToUpdate.Services_Title + "изменена";
                }
            }
            return result;
        }
        #endregion

        #region ClientModel
        //добавление нового клиента
        public static string CreateClient(string name, Cars Cars)
        {
            string result = "Уже существует!";
            using (ApplicationContext db = new ApplicationContext())
            {
                bool checkIsExist = db.Client.Any(el => el.Name == name);
                if (!checkIsExist)
                {
                    Client newClient = new Client(name, Cars);
                    db.Client.Add(newClient);
                    db.SaveChanges();
                    result = "Сделано!";
                }
                return result;
            }
        }
        //удаление клиента
        public static string DeleteClient(Client client)
        {
            string result = "Такой услуги нет";
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Client.Remove(client);
                db.SaveChanges();
                result = "Сделано! Клиент" + client.Name + "удален";
            }
            return result;
        }
        //редактирование клиента
        public static string EditClient(Client OldClient, string newName)
        {
            string result = "Такой услуги нет";
            using (ApplicationContext db = new ApplicationContext())
            {
                Client ClientToUpdate = db.Client.FirstOrDefault(d => d.Id == OldClient.Id);
                if (ClientToUpdate != null)
                {
                    ClientToUpdate.Name = newName;
                    db.Client.Remove(ClientToUpdate);
                    db.SaveChanges();
                    result = "Сделано! Клиент" + ClientToUpdate.Name + "изменен";
                }
            }
            return result;
        }
        #endregion

        #region ProblemsModel
        //создать новую проблему
        public static string CreateProblems(string title, string description, double cost)
        {
            string result = "Уже существует!";
            using (ApplicationContext db = new ApplicationContext())
            {
                bool checkIsExist = db.Problems.Any(el => el.Title == title);
                if (!checkIsExist)
                {
                    Problems newProblems = new Problems(title, description, cost);
                    db.Problems.Add(newProblems);
                    db.SaveChanges();
                    result = "Сделано!";
                }
                return result;
            }
        }
        //удаление проблемы
        public static string DeleteProblems(Problems problems)
        {
            string result = "Такой проблемы нет";
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Problems.Remove(problems);
                db.SaveChanges();
                result = "Сделано! Проблема" + problems.Title + "удалена";
            }
            return result;
        }
        //редактирование проблемы
        public static string EditProblems(Problems OldProblems, string newTitle, string newDescription, double newCost)
        {
            string result = "Такой проблемы нет";
            using (ApplicationContext db = new ApplicationContext())
            {
                Problems problemsToUpdate = db.Problems.FirstOrDefault(d => d.Id == OldProblems.Id);
                if (problemsToUpdate != null)
                {
                    problemsToUpdate.Title = newTitle;
                    problemsToUpdate.Description = newDescription;
                    problemsToUpdate.Cost = newCost;
                    db.Problems.Remove(problemsToUpdate);
                    db.SaveChanges();
                    result = "Сделано! Проблема" + problemsToUpdate.Title + "изменена";
                }
            }
            return result;
        }
        #endregion

        #region CarsModel
        //добавить новую машину 
        public static string CreateCars(string make, string model, string carvin, int year, string color)
        {
            string result = "Уже существует!";
            using (ApplicationContext db = new ApplicationContext())
            {
                bool checkIsExist = db.Cars.Any(el => el.CarVin == carvin);
                if (!checkIsExist)
                {
                    Cars newCars = new Cars(make, model, carvin,year, color);
                    db.Cars.Add(newCars);
                    db.SaveChanges();
                    result = "Сделано!";
                }
                return result;
            }
        }
        //удалить машину
        public static string DeleteCars(Cars car)
        {
            string result = "Такой машины нет";
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Cars.Remove(car);
                db.SaveChanges();
                result = "Сделано! Машина" + car.CarVin + "удалена";
            }
            return result;
        }
        //редактировать машину
        public static string EditCars(Cars OldCar, string newMake, string newModel, string newCarvin, int newYear, string newColor)
        {
            string result = "Такой машины нет";
            using (ApplicationContext db = new ApplicationContext())
            {
                Cars carToUpdate = db.Cars.FirstOrDefault(d => d.Id == OldCar.Id);
                if (carToUpdate != null)
                {
                    carToUpdate.Make = newMake;
                    carToUpdate.Model = newModel;
                    carToUpdate.CarVin = newCarvin;
                    carToUpdate.Year = newYear;
                    carToUpdate.Color = newColor;
                    db.Cars.Remove(carToUpdate);
                    db.SaveChanges();
                    result = "Сделано! Машина" + carToUpdate.CarVin + "изменена";
                }
            }
            return result;
        }
        #endregion

        #region WorkerModel
        //добавить нового работника
        public static string CreateWorker(string Name, decimal Salary)
        {
            string result = "Уже существует!";
            using (ApplicationContext db = new ApplicationContext())
            {
                bool checkIsExist = db.Worker.Any(el => el.Name == Name);
                if (!checkIsExist)
                {
                    Worker newWorker = new Worker(Name, Salary);
                    db.Worker.Add(newWorker);
                    db.SaveChanges();
                    result = "Сделано!";
                }
                return result;
            }
        }
        //удалить работника
        public static string DeleteWorker(Worker worker)
        {
            string result = "Такого работника нет";
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Worker.Remove(worker);
                db.SaveChanges();
                result = "Сделано! Работник" + worker.Name + "удален";
            }
            return result;
        }
        //редактировать работников
        public static string EditWorker(Worker OldWorker, string newName, decimal newSalary)
        {
            string result = "Такого работника нет";
            using (ApplicationContext db = new ApplicationContext())
            {
                Worker workerToUpdate = db.Worker.FirstOrDefault(d => d.Id == OldWorker.Id);
                if (workerToUpdate != null)
                {
                    workerToUpdate.Name = newName;
                    workerToUpdate.Salary = newSalary;
                    db.Worker.Remove(workerToUpdate);
                    db.SaveChanges();
                    result = "Сделано! Работник" + workerToUpdate.Name + "изменен";
                }
            }
            return result;
        }
        #endregion

        #region OrderModel
        //добавление нового заказа
        public static string CreateOrder(Client client,Cars cars, List<Problems> problems, List<Services> services, List<Worker> workers)
        {
            string result = "Уже существует!";
            using (ApplicationContext db = new ApplicationContext())
            {
                // Проверяем, есть ли уже заказ для данного клиента
                bool checkIsExist = db.Order.Any(el => el.Client == client);
                if (!checkIsExist)
                {
                    // Создаем новый заказ
                    Order newOrder = new Order(client,cars,problems,services,workers);
                    db.Order.Add(newOrder);
                    db.SaveChanges();
                    result = "Сделано!";
                }
                return result;
            }
        }
        //Удаление заказа
        public static string DeleteOrder(Order order)
        {
            string result = "Такого заказа нет";
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Order.Remove(order);
                db.SaveChanges();
                result = "Сделано! Заказ" + order + "удален";
            }
            return result;
        }
        //Редактирование заказа
        public static string EditOrder(Order OldOrder, Client client, Cars Car, List<Problems> problems, List<Services> services, List<Worker> workers)
        {
            string result = "Такой услуги нет";
            using (ApplicationContext db = new ApplicationContext())
            {
                Order orderToUpdate = db.Order.FirstOrDefault(d => d.Id == OldOrder.Id);
                if (orderToUpdate != null)
                {
                    orderToUpdate.Client = client;
                    orderToUpdate.Cars = Car;
                    orderToUpdate.Problems = problems;
                    orderToUpdate.Services = services;
                    orderToUpdate.Workers = workers;
                    db.Order.Remove(orderToUpdate);
                    db.SaveChanges();
                    result = "Сделано! Услуга" + orderToUpdate + "изменена";
                }
            }
            return result;
        }
        #endregion
    }
}
