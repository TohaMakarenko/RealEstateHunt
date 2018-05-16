using System.Collections.Generic;
using System.Linq;

namespace RealEstateHunt.Infrastructure.Repositories.EfRepositories
{
    class UserRepository : EfRepository<UserEntity>, IUserRepository
    {
        public UserRepository(RehDbContext dbContext) : base(dbContext)
        {
        }

        public override IEnumerable<UserEntity> GetEntities()
        {
            return DbContext.Users;
        }

        public override IEnumerable<UserEntity> GetPage(int pageNumber, int pageSize)
        {
            return DbContext.Users
                .Skip(pageNumber * pageSize)
                .Take(pageSize);
        }

        public IEnumerable<UserEntity> FindByName(string name)
        {
            return DbContext.Users
                .Where(u => u.Name == name);
        }
    }
}