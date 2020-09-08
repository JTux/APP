﻿using APollPoll.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APollPoll.Services.Resources
{
    public abstract class BaseService<TEntity, TCreate, TDetail, TListItem, TUpdate> 
        : IService<TEntity, TCreate, TDetail, TListItem, TUpdate>
        where TEntity : class
        where TCreate : class
        where TDetail : class
        where TListItem : class
        where TUpdate : class
    {
        protected readonly AppDbContext _context = new AppDbContext();
        protected DbSet EntityDbSet => _context.Set<TEntity>();

        // Create
        public async Task<bool> CreateAsync(TCreate createModel)
        {
            var entity = GetEntity(createModel);
            EntityDbSet.Add(entity);
            return await _context.SaveChangesAsync() == 1;
        }

        // Read
        public async Task<TDetail> GetByIdAsync(int id)
        {
            var entity = await GetEntityAsync(id);
            if (entity is null)
                return null;

            return GetDetail(entity);
        }

        // Read All
        public async Task<List<TListItem>> GetAllAsync()
        {
            var entities = await EntityDbSet.ToListAsync().ConfigureAwait(false);
            return entities.Select(e => GetListItem(e as TEntity)).ToList();
        }

        // Update
        public async Task<bool> UpdateAsync(TUpdate model)
        {
            var entity = GetEntity(model);
            _context.Entry(entity).State = EntityState.Modified;
            return await _context.SaveChangesAsync() == 1;
        }

        // Delete
        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await GetEntityAsync(id);
            EntityDbSet.Remove(entity);
            return await _context.SaveChangesAsync() == 1;
        }

        protected async Task<TEntity> GetEntityAsync(int id)
        {
            return await EntityDbSet.FindAsync(id) as TEntity;
        }

        protected abstract TEntity GetEntity(TCreate model);
        protected abstract TEntity GetEntity(TUpdate model);
        protected abstract TListItem GetListItem(TEntity entity);
        protected abstract TDetail GetDetail(TEntity entity);
    }
}
