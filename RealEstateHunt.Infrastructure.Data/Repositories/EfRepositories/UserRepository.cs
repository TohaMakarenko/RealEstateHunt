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

        public override async Task<IEnumerable<User>> GetEntitiesAsync()
        {
            return Mapper.Map<IEnumerable<UserEntity>, IEnumerable<User>>(
                await DbContext.Users
                    .ToListAsync());
        }

        public override async Task<IEnumerable<User>> GetPageAsync(int pageNumber, int pageSize)
        {
            return Mapper.Map<IEnumerable<UserEntity>, IEnumerable<User>>(
                await DbContext.Users
                    .Skip(pageNumber * pageSize)
                    .Take(pageSize)
                    .ToListAsync());
        }

        public async Task<IEnumerable<User>> FindByNameAsync(string name)
        {
            return Mapper.Map<IEnumerable<UserEntity>, IEnumerable<User>>(
                await DbContext.Users
                    .Where(u => u.Name == name)
                    .ToListAsync());
        }
    }
}