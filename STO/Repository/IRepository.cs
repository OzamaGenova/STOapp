﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STO.Repository
{
    public interface IRepository<T>
    {
        Task Add(T entity);
        Task Delete(int id);
        Task Update(int id);
        Task<IEnumerable<T>> GetAll();

    }
}
