
using Microsoft.EntityFrameworkCore;

namespace CustomBlogsAPI.DAL.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    { 
        private readonly appDBContext _dbContext;
        public Repository(appDBContext _mydbContext)
        {
            _dbContext = _mydbContext;
        }

       // public appDBContext AppDBContext { get; }

        public async Task AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _dbContext.Set<T>().FindAsync(id);
            _dbContext.Set<T>().Remove(entity);
        }

        public async Task<List<T>> GetAll()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            //var entity = await _dbContext.Set<T>().FindAsync(id);
            _dbContext.Set<T>().Update(entity);
        }
    }
}
