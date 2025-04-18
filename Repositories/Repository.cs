﻿using Microsoft.EntityFrameworkCore;
using PrimeiraAPI.Context;
using PrimeiraAPI.Repositories.Interfaces;
using System.Linq.Expressions;

namespace PrimeiraAPI.Repositories
{
    public class Respository<T> : IRepository<T> where T : class
    {
        // protected pois essa classe será ultilizada em classes derivadas
        protected readonly AppDbContext _context;

        public Respository(AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<T> GetAll()
        {
           return _context.Set<T>().AsNoTracking().ToList();
        }

        public T? Get(Expression<Func<T, bool>> predicate)
        {
           return _context.Set<T>().FirstOrDefault(predicate);
           
        }
        public T Create(T entity)
        {
            _context.Set<T>().Add(entity);
            // _context.SaveChanges();
            return entity;  
        }
        public T Update(T entity)
        {
            _context.Set<T>().Update(entity);
           //_context.SaveChanges();
            return entity;  
        }

        public T Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            //_context.SaveChanges();
            return entity;
        }
        
    }
}
