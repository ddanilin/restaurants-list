using RestaurantsList.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantsList.Abstractions
{
    public interface IRestaurantsRepository : IAsyncRepository<Restaurants>
    {
        Task<(IEnumerable<Restaurant>, int count)> GetRestaurantsByCityAsync(long cityId, int pageNumber, int pageSize);
    }
}
