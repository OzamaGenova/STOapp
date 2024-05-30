using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using STO.Models.Data;

namespace STO.Models
{
    public static class DataWorker
    {
        //Получить все услуги
        public static List<Services> GetAllServices()
        {
            using(ApplicationContext db = new ApplicationContext())
            {
                var result = db.Services.ToList();
                return result;
            }
        }
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
    }
}
