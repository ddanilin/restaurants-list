namespace RestaurantsList.Models
{
    public sealed class Restaurants : BaseModel
    {
        public long CityId { get; set; }

        public long RestaurantId { get; set; }
    }
}
