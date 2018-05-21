using RealEstateHunt.Core;
using System.Collections.Generic;
using System.Linq;
using RealEstateHunt.Infrastructure.Mappers;

namespace RealEstateHunt.Infrastructure.Repositories.EfRepositories
{
    public class UserRepository : EfRepository<User, UserEntity>, IUserRepository
    {
        public UserRepository(RehDbContext dbContext,
            IMapper<User, UserEntity> toEntityMapper,
            IMapper<UserEntity, User> fromEntityMapper)
            : base(dbContext, toEntityMapper, fromEntityMapper)
        {
        }

        public override IEnumerable<User> GetEntities()
        {
            return FromEntityMapper.MapCollection(DbContext.Users);
        }

        public override IEnumerable<User> GetPage(int pageNumber, int pageSize)
        {
            return FromEntityMapper.MapCollection(
                DbContext.Users
                .Skip(pageNumber * pageSize)
                .Take(pageSize));
        }

        public IEnumerable<User> FindByName(string name)
        {
            return FromEntityMapper.MapCollection(
                DbContext.Users
                .Where(u => u.Name == name));
        }
    }
}