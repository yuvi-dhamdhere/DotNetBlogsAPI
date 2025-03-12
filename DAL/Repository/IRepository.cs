namespace CustomBlogsAPI.DAL.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<T> GetById(int id);
        Task AddAsync(T entity);   
        Task DeleteAsync(int id);
        void Update(T entity);
        Task SaveChangesAsync();
    }
}
