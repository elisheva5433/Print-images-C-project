using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    internal interface IGenericActionDB<T> where T:class
    {
        void Create(T obj);
        T Find<TKey>(TKey Key);

        void Delete<TKey>(TKey Key);
    }
}
