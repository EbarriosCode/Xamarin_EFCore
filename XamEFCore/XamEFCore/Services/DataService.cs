using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using XamEFCore.Models;

namespace XamEFCore.Services
{
    public class DataService
    {
        private readonly ProductsDbContext _context;

        public DataService()
        {
            _context = App.GetContext();
        }

        public bool Create<T>(T record) where T : class
        {
            bool created = false;
            try
            {
                _context.Entry(record).State = EntityState.Added;
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

        public void GetList<T>() where T : class
        {
            try
            {
                var list = _context.Set<T>();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async void SaveList<T>(List<T> list) where T : class
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

        public async void DeleteList<T>(List<T> list) where T : class
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
