using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager_ITechArt.DAL.Entities;

namespace TaskManager_ITechArt.DAL.Interfaces
{
    interface IRepository<T> where T: class
    {
        List<T> GetAll();
        T Get(int id);
        T Create(T item);
        void Update(T item);
        void Delete(int id);
    }
}
