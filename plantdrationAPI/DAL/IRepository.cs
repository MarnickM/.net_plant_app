namespace PlantdrationAPI.DAL
{
    public interface IRepository<T>
    {
       Task<IEnumerable<T>> GetAll();

       Task<T> GetByID(int id);

       Task<T> GetByName(string name);

       Task Insert(T obj);

       void Delete(int id);

       T Update(T obj);
       Task Save();
    }
}
