using BookStore.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace BookStore.Core.Repositories
{
    public class BaseRepo<T> : IBaseRepo<T> where T : class
    {
        protected readonly DbContext _context = new EFContext();

        public BaseRepo()
        { }

        public async Task Insert(T entity)
        {
            try
            {
                _context.Set<T>().Add(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex) { throw new ArgumentException($"{ex.Message}"); }
        }
        public async Task Delete(T entity)
        {
            try
            {
                _context.Set<T>().Remove(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex) { throw new ArgumentException($"{ex.Message}"); }
        }

        public async Task Delete(object id)
        {
            try
            {
                T entity = await _context.Set<T>().FindAsync(id);
                _context.Set<T>().Remove(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex) { throw new ArgumentException($"{ex.Message}"); }
        }

        public async Task Update(T entity)
        {
            try
            {
                _context.Set<T>().Attach(entity);
                _context.Entry(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex) { throw new ArgumentException($"{ex.Message}"); }
        }

        public async Task<T> GetById(object id)
        {
            try
            {
                return await _context.Set<T>().FindAsync(id);
            }
            catch (Exception ex) { throw new ArgumentException($"{ex.Message}"); }
        }

        public async Task<IEnumerable<T>> GetItems()
        {
            try
            {
                return await _context.Set<T>().ToListAsync();
            }
            catch (Exception ex) { throw new ArgumentException($"{ex.Message}"); }
        }
    }
}
