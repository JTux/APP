using APollPoll.Data.Contexts;
using AutoMapper;
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
        private readonly IMapper _mapper;

        protected readonly AppDbContext _context = new AppDbContext();
        protected DbSet EntityDbSet => _context.Set<TEntity>();

        public BaseService(IMapper mapper)
        {
            _mapper = mapper;
        }

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

        protected async Task<TEntity> GetEntityAsync(int id) => await EntityDbSet.FindAsync(id) as TEntity;

        protected virtual TEntity GetEntity(TCreate model) => _mapper.Map<TEntity>(model);
        protected virtual TEntity GetEntity(TUpdate model) => _mapper.Map<TEntity>(model);
        protected virtual TListItem GetListItem(TEntity entity) => _mapper.Map<TListItem>(entity);
        protected virtual TDetail GetDetail(TEntity entity) => _mapper.Map<TDetail>(entity);
    }
}
