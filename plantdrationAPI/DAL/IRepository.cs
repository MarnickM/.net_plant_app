namespace PlantdrationAPI.DAL
{
    public interface IRepository<T>
    {
       Task<IEnumerable<T>> GetAll();

       Task<T> GetByID(int id);

       Task Insert(T obj);

       void Delete(int id);

       T Update(T obj);
       Task Save();
    }
}
