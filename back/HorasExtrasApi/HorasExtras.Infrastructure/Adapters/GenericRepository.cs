using HorasExtras.Domain.Ports;
using HorasExtras.Domain.Utils;
using HorasExtras.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HorasExtras.Infrastructure.Adapters
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DatabaseContext _context;
        public GenericRepository(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<T> AddAsync(T entity)
        {
            _ = entity ?? throw new ArgumentNullException(nameof(entity), "No puede ser nulo");
            _context.Set<T>().Add(entity);
            await this.CommitAsync();
            return entity;
        }


        public async Task DeleteAsync(T entity)
        {
            if (entity != null)
            {
                _context.Set<T>().Remove(entity);
                await this.CommitAsync();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task<RespuestaPaginada<T>> GetAsyncPaginated(Expression<Func<T, bool>>? filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            int skip = 0, int take = 0,
            string includeProperties = "")
        {
            RespuestaPaginada<T> respuesta = new();
            IQueryable<T> query = _context.Set<T>();
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProperty in includeProperties.Split(
                    new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            if (orderBy != null)
            {
                respuesta.Items = await orderBy(query).Skip(skip).Take(take).ToListAsync();
            }
            else
            {
                respuesta.Items = await query.Skip(skip).Take(take).ToListAsync();
            }
            respuesta.Total = query.Count();
            return respuesta;

        }


        public async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>>? filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            string includeProperties = "", bool isTracking = false)
        {
            IQueryable<T> query = _context.Set<T>();
            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProperty in includeProperties.Split(
                    new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }
            return (!isTracking) ? await query.AsNoTracking().ToListAsync() : await query.ToListAsync();
        }

        public async Task<T> GetByIdAsync(object id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            if (entity != null)
            {
                _context.Set<T>().Update(entity);
                await this.CommitAsync();
            }
        }

        public async Task CommitAsync()
        {
            await _context.CommitAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            this._context.Dispose();
        }
    }
}
