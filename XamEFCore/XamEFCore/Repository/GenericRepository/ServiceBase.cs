using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using XamEFCore.Models;

namespace XamEFCore.Repository.GenericRepository
{
    public class ServiceBase<T> where T : class
    {
        private readonly ProductsDbContext _context;

        public ServiceBase()
        {
            _context = App.GetContext();
        }

        public bool Create(T entity)
        {
            bool created = false;
            try
            {
                //_context.Set<T>().Add(entity);
                _context.Entry(entity).State = EntityState.Added;
                _context.SaveChanges();

                created = true;
            }
            catch (Exception)
            {
                created = false;
                throw;
            }

            return created;
        }

        public void Delete(T entity)
        {
            T existing = _context.Set<T>().Find(entity);
            if (existing != null)
            {
                _context.Set<T>().Remove(existing);
                _context.SaveChanges();
            }
        }

        public IEnumerable<T> Get()
        {
            return _context.Set<T>().AsEnumerable<T>();
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate).AsEnumerable<T>();
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> whereCondition = null,
                                  Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                  string includeProperties = "")
        {
            IQueryable<T> query = _context.Set<T>();

            if (whereCondition != null)
            {
                query = query.Where(whereCondition);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.Set<T>().Attach(entity);
            _context.SaveChanges();
        }

        public async void SaveList(List<T> list)
        {
            try
            {
                foreach (var record in list)
                {
                    _context.Add(record);
                }
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async void DeleteList(List<T> list)
        {
            try
            {
                foreach (var record in list)
                {
                    _context.Remove(record);
                }
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}