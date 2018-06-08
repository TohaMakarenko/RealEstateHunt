using System;
using RealEstateHunt.Core.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RealEstateHunt.Core.Data.Models;
using RealEstateHunt.Core.Data.Repositories;
using RealEstateHunt.Infrastructure.Data.Entities;

namespace RealEstateHunt.Infrastructure.Data.Repositories.EfRepositories
{
    public class UserRepository : EfRepository<User, UserEntity>, IUserRepository
    {
        public UserRepository(RehDbContext dbContext, IMapper mapper) : base(dbContext, mapper) { }

        protected override IQueryable<UserEntity> IncludeEntities(IQueryable<UserEntity> dbSet)
        {
            return dbSet.Include(e => e.Contact);
        }

        public override async Task<User> FindByIdAsync(int id)
        {
            if (id <= 0) throw new ArgumentOutOfRangeException(nameof(id));

            return Mapper.Map<UserEntity, User>(
                await IncludeCollections(IncludeEntities(DbContext.Users))
                    .FirstOrDefaultAsync(e => e.Id == id));
        }

        public override async Task<IEnumerable<User>> GetEntitiesAsync()
        {
            return Mapper.Map<IEnumerable<UserEntity>, IEnumerable<User>>(
                await IncludeEntities(DbContext.Users)
                    .ToListAsync());
        }

        public override async Task<IEnumerable<User>> GetPageAsync(int pageNumber, int pageSize)
        {
            if (pageNumber < 0) throw new ArgumentOutOfRangeException(nameof(pageNumber));
            if (pageSize <= 1) throw new ArgumentOutOfRangeException(nameof(pageSize));

            return Mapper.Map<IEnumerable<UserEntity>, IEnumerable<User>>(
                await IncludeEntities(DbContext.Users)
                    .Skip(pageNumber * pageSize)
                    .Take(pageSize)
                    .ToListAsync());
        }

        public async Task<IEnumerable<User>> FindByNameAsync(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));

            return Mapper.Map<IEnumerable<UserEntity>, IEnumerable<User>>(
                await IncludeEntities(DbContext.Users)
                    .Where(u => u.Name == name)
                    .ToListAsync());
        }
    }
}