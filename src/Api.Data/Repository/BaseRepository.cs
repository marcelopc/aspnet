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
        public Task<bool> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
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

        public Task<T> SelectAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> SelectAsync()
        {
            throw new NotImplementedException();
        }

        public Task<T> UpdatetAsync(T item)
        {
            throw new NotImplementedException();
        }
    }
}
