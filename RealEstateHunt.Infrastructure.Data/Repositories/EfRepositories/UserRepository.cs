using RealEstateHunt.Core.Data;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using RealEstateHunt.Core.Data.Repositories;

namespace RealEstateHunt.Infrastructure.Data.Repositories.EfRepositories
{
    public class UserRepository : EfRepository<User, UserEntity>, IUserRepository
    {
        public UserRepository(RehDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public override IEnumerable<User> GetEntities()
        {
            return mapper.Map<IEnumerable<UserEntity>, IEnumerable<User>>(DbContext.Users);
        }

        public override IEnumerable<User> GetPage(int pageNumber, int pageSize)
        {
            return mapper.Map<IEnumerable<UserEntity>, IEnumerable<User>>(
                DbContext.Users
                .Skip(pageNumber * pageSize)
                .Take(pageSize));
        }

        public IEnumerable<User> FindByName(string name)
        {
            return mapper.Map<IEnumerable<UserEntity>, IEnumerable<User>>(
                DbContext.Users
                .Where(u => u.Name == name));
        }
    }
}