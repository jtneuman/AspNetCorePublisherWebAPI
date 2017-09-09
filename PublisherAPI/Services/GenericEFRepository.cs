﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using PublisherWebAPI.Entities;

namespace PublisherWebAPI.Services
{
    public class GenericEFRepository : IGenericEFRepository
    {
        private SqlDbContext _db;

        public GenericEFRepository(SqlDbContext db)
        {
            _db = db;
        }

        public void Add<TEntity>(TEntity item) where TEntity : class
        {
            _db.Add<TEntity>(item);
        }

        public IEnumerable<TEntity> Get<TEntity>() where TEntity : class
        {
            return _db.Set<TEntity>();
        }

        public TEntity Get<TEntity>(int id, bool includeRelatedEntities = false) where TEntity : class
        {
            var entity = _db.Set<TEntity>().Find(new object[] { id });
            if (entity != null && includeRelatedEntities)
            {
                // Get the names of all DbSets in the DbContext
                var dbsets = typeof(SqlDbContext)
                    .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                    .Where(z => z.PropertyType.Name.Contains("DbSet"))
                    .Select(z => z.Name);

                // Get the names all the properties (tables) in the generic type T that is represented by a DbSet
                var tables = typeof(TEntity)
                    .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                    .Where(z => dbsets.Contains(z.Name))
                    .Select(z => z.Name);

                // Eager load all the tables referenced by the generic type T
                if (tables.Count() > 0)
                    foreach (var table in tables)
                        _db.Entry(entity).Collection(table).Load();
            }
            return entity;
        }

        public bool Save()
        {
            return _db.SaveChanges() >= 0;
        }
    }
}
