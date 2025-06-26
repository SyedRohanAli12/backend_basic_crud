using System;
using Microsoft.EntityFrameworkCore;
using Think_Digitally_week01.Data;
using Think_Digitally_week01.Models;

namespace Think_Digitally_week01.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly AppDbContext _context;
        private readonly DbSet<T> _entities;

        public Repository(AppDbContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }

        public void Add(T entity)
        {
            _entities.Add(entity);
            _context.SaveChanges();
        }

        public List<T> GetAll()
        {
            return _entities.ToList();
        }

        public T GetById(int id)
        {
            return _entities.FirstOrDefault(e => e.Id == id);
        }

        public string Update(T entity)
        {
            var existing = GetById(entity.Id);
            if (existing == null) return $"ID {entity.Id} not found.";

            entity.UpdatedAt = DateTime.UtcNow;
            _context.Entry(existing).CurrentValues.SetValues(entity);
            _context.SaveChanges();
            return $"ID {entity.Id} updated.";
        }

        public void Delete(T entity)
        {
            var existing = GetById(entity.Id);
            if (existing != null)
            {
                existing.IsDeleted = true;
                _context.SaveChanges();
            }
        }
    }
}