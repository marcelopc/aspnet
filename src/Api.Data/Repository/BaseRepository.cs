using Data.Context;
using Domain.Entites;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly MyContext _context;
        private DbSet<T> _dataset;
        public BaseRepository(MyContext context) {
            _context = context;
            _dataset = _context.Set<T>();
        }
        public async Task<bool> DeleteAsync(Guid id)
        {
             try
            {
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<T> InsertAsync(T item)
        {
            try
            {
                if(item.id == Guid.Empty)
                {
                    item.id = Guid.NewGuid();
                }

                item.createAt = DateTime.Now;
                item.updateAt = DateTime.Now;

                _dataset.Add(item);

                await _context.SaveChangesAsync();
                return item;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<T> SelectAsync(Guid id)
        {
            try
            {
                return null;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<IEnumerable<T>> SelectAsync()
        {
            try
            {
                return null;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<T> UpdatetAsync(T item)
        {
            try
            {
                var result = await _dataset.SingleOrDefaultAsync(p => p.id.Equals(item.id));
                
                if (result == null)
                {
                    return null;
                }

                item.updateAt = DateTime.UtcNow;
                item.createAt = result.createAt;
                
                _context.Entry(result).CurrentValues.SetValues(item);
                await _context.SaveChangesAsync();
                return item;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
