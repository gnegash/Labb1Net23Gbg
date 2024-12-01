namespace Repository
{
    //bas interface som alla andra repon kan ärva generiska(T) operationer av
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();

        void Add(T item);

        void Delete(int id);

        void Update(T item);
    }
}
