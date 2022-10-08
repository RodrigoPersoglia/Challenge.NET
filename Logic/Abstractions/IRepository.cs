using System.Collections.Generic;

namespace Logic.Abstractions
{
    public interface IRepository<T>
    {
        IEnumerable<T> AsEnumerable();

        void Add(T item);
    }
}