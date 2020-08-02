using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestaurantsList.DataAccess.MSSQL.Entities;

namespace RestaurantsList.DataAccess.MSSQL.Config
{
    public class RestaurantsConfiguration : IEntityTypeConfiguration<Restaurants>
    {
        public void Configure(EntityTypeBuilder<Restaurants> builder)
        {
            builder.ToTable("Restaurants");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.CityId)
                .IsRequired();

            builder.Property(p => p.RestaurantId)
                .IsRequired();

            builder
                .HasOne(p => p.City)
                .WithMany(p => p.Restaurants)
                .HasForeignKey(p => p.CityId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(p => p.Restaurant)
                .WithMany(p => p.Restaurants)
                .HasForeignKey(p => p.RestaurantId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
