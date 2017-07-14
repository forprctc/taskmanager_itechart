using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager_iTechArt.Besiness_Logic.Interface
{
    interface IProvider<T> where T:class
    {
        void Make(T item);
        IEnumerable<T> GetAll();
        T Get(int id);
        void Update(T item);
        void Delete(T item);
    }
}
