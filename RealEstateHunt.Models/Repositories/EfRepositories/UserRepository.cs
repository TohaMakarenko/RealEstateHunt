using System.Collections.Generic;
using System.Linq;

namespace RealEstateHunt.Models.Repositories.EfRepositories
{
    class UserRepository : EfRepository<User>, IUserRepository
    {
        public UserRepository(RehDbContext dbContext) : base(dbContext)
        {
        }

        public override IEnumerable<User> GetEntities()
        {
            return DbContext.Users;
        }

        public override IEnumerable<User> GetPage(int pageNumber, int pageSize)
        {
            return DbContext.Users
                .Skip(pageNumber * pageSize)
                .Take(pageSize);
        }

        public IEnumerable<User> FindByName(string name)
        {
            return DbContext.Users
                .Where(u => u.Name == name);
        }
    }
}