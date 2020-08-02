using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RestaurantsList.Abstractions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantsList.DataAccess.MSSQL.Repositories
{
    public class RestaurantsRepository : AsyncRepository<Models.Restaurants, Entities.Restaurants>, IRestaurantsRepository
    {
        public RestaurantsRepository(IMapper mapper, ApplicationDbContext dbContext)
            : base(mapper, dbContext)
        { }

        public async Task<(IEnumerable<Models.Restaurant>, int count)> GetRestaurantsByCityAsync(long cityId, int pageNumber, int pageSize)
        {
            var count = await DbContext.Set<Entities.Restaurants>()
                .Where(x => x.CityId == cityId)
                .CountAsync();
            
            var result = await DbContext.Set<Entities.Restaurants>()
                .Where(x => x.CityId == cityId)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Include(x => x.Restaurant)
                .ToListAsync();

            return (
                result.Select(x => Mapper.Map<Models.Restaurant>(x.Restaurant)),
                count
            );
        }
    }
}
