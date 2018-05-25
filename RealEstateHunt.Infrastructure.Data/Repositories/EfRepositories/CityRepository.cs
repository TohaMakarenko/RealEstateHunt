﻿using RealEstateHunt.Core.Data;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using RealEstateHunt.Core.Data.Models;
using RealEstateHunt.Core.Data.Repositories;
using RealEstateHunt.Infrastructure.Data.Entities;

namespace RealEstateHunt.Infrastructure.Data.Repositories.EfRepositories
{
    public class CityRepository : EfRepository<City, CityEntity>, ICityRepository
    {
        public CityRepository(RehDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public override IEnumerable<City> GetEntities()
        {
            return mapper.Map<IEnumerable<CityEntity>, IEnumerable<City>>(DbContext.Cities);
        }

        public override IEnumerable<City> GetPage(int pageNumber, int pageSize)
        {
            return mapper.Map<IEnumerable<CityEntity>, IEnumerable<City>>(
                DbContext.Cities
                .Skip(pageNumber * pageSize)
                .Take(pageSize));
        }
    }
}
