using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ISRPO.Fourth.Domain.Models;
using ISRPO.Fourth.Domain.Repositories.Base;
using ISRPO.Fourth.Infrastructure.AutoMapping;
using ISRPO.Fourth.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ISRPO.Fourth.Infrastructure.Repositories.Base
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : Entity
    {
        private readonly IMapper _mapper;
        private readonly ApplicationContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public Repository(ApplicationContext context)
        {
            _context = context;
            _mapper = new Mapper(new MapperConfiguration(configuration => configuration.AddProfile<EntityMappingProfile>()));
            _dbSet = _context.Set<TEntity>();
        }

        public async Task<TEntity> Create(TEntity entity)
        {
            var existedEntity = await _dbSet.FirstOrDefaultAsync(x => x.Id == entity.Id);

            if (existedEntity != null)
                return null;

            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public IQueryable<TEntity> Read()
        {
            return _dbSet.AsQueryable().Where(entity => !entity.Deleted);
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            var existedEntity = await _dbSet.FirstOrDefaultAsync(x => x.Id == entity.Id);

            if (existedEntity == null)
                return null;

            _mapper.Map(entity, existedEntity);

            existedEntity.UpdatedAt = DateTime.Now;

            _dbSet.Update(existedEntity);
            await _context.SaveChangesAsync();

            return existedEntity;
        }

        public async Task<bool> Delete(TEntity entity)
        {
            var existedEntity = await _dbSet.FirstOrDefaultAsync(x => x.Id == entity.Id);

            if (existedEntity == null)
                return false;

            existedEntity.Deleted = true;

            _dbSet.Update(existedEntity);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}