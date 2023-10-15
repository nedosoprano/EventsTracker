namespace EventsTracker.Application
{
    public interface IService<T>
    {
        public void Add(T entity);
    }
}
