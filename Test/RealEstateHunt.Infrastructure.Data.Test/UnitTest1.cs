using System;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace RealEstateHunt.Infrastructure.Data.Test
{
    public class RehDbContextTest
    {
        [Fact]
        public void CreateDbTest()
        {
            using (var db = new RehDbContext(new DbContextOptionsBuilder<RehDbContext>()
                .UseSqlServer(Configuration.ConnectionString)
                .Options)) {
                db.Database.EnsureCreated();
            }
        }
    }
}