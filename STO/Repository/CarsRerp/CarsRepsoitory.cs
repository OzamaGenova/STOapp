using Microsoft.EntityFrameworkCore;
using STO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STO.Repository.CarsRerp
{
    public class CarsRepsoitory : ICarsRepository
    {
        protected Database _db;
        public CarsRepsoitory( Database repository)
        { 
            _db = repository; 
        }
        public async Task Add(Cars entity)
        {
            await _db.Cars.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var car = await _db.Cars.Where(carId => carId.Id == id).FirstOrDefaultAsync();

            if(car is  null)
            {
                return;
            }

            _db.Cars.Remove(car);
            await _db.SaveChangesAsync();
        }

        public Task<IEnumerable<Cars>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Update(int id)
        {
            throw new NotImplementedException();
        }
    }
}
