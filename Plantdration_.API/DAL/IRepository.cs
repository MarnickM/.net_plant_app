namespace Plantdration_.API.DAL
{
    public interface IRepository<T>
    {
       IEnumerable<T> GetAll();

       T GetByID(int id);

       Task Insert(T obj);

       Task Delete(int id);

       T Update(T obj);
       Task Save();
    }
}
