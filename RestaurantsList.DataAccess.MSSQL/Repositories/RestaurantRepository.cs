using AutoMapper;
using RestaurantsList.Abstractions;

namespace RestaurantsList.DataAccess.MSSQL.Repositories
{
    public class RestaurantRepository : AsyncRepository<Models.Restaurant, Entities.Restaurant>, IAsyncRepository<Models.Restaurant>
    {
        public RestaurantRepository(IMapper mapper, ApplicationDbContext dbContext)
            : base(mapper, dbContext)
        { }
    }
}
