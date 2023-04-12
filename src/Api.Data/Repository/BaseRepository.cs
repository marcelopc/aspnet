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
                var result = await _dataset.SingleOrDefaultAsync(p => p.id.Equals(id));

                if (result == null) {
                    return false;
                }

                result.status = Status.inativo;
                _context.Entry(result).CurrentValues.SetValues(result);
                await _context.SaveChangesAsync();

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
                item.status = Status.ativo;

                _dataset.Add(item);

                await _context.SaveChangesAsync();
                return item;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<bool> ExistAsync(Guid id)
        {
            try
            {
                return await _dataset.AnyAsync(p => p.id.Equals(id));

            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<T> SelectAsync(Guid id)
        {
            try
            {
                return await _dataset.SingleOrDefaultAsync(p => p.id.Equals(id));
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
                return await _dataset.ToListAsync();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<T> UpdateAsync(T item)
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
