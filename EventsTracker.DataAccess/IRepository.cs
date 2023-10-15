using System;

namespace EventsTracker.DataAccess
{
    public interface IRepository<T>
    {
        void Add(T entity);

        void AddRange(IEnumerable<T> entities);
    }
}
