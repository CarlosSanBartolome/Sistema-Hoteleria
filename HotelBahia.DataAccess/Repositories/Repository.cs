﻿using HotelBahia.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace HotelBahia.DataAccess.Repositories
{
    public class Repository<T> where T : class
    {
        protected readonly HoteleriaContext _context;
        public virtual  DbSet<T> _dbSet { get; set;}

        public DbContext UnitOfWork { get => _context; }

        public Repository(HoteleriaContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void Edit(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            IEnumerable<T> query = _dbSet.Where(predicate);
            return query;
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.AsEnumerable();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
