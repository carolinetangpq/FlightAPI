using Microsoft.EntityFrameworkCore;

namespace WebApiFlightInfo.Models
{

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Flight> Flights { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Flight>().HasData(
                new Flight
                {
                    flightId = "SIA606",
                    flightSource = "SINGAPORE", 
                    flightDestination = "SEOUL, SOUTH KOREA",
                    flightDateTime = new System.DateTime(2023, 11, 4, 13, 0, 0)
                },
                new Flight
                {
                    flightId = "BAW304",
                    flightSource = "LONDON, UNITED KINGDOM", 
                    flightDestination = "PARIS, FRANCE", 
                    flightDateTime = new System.DateTime(2023, 10, 6, 12, 23, 30, 0)
                },

                new Flight
                {
                    flightId = "TGW24",
                    flightSource = "SINGAPORE",
                    flightDestination = "MELBOURNE, AUSTRALIA",
                    flightDateTime = new System.DateTime(2023, 12, 3, 20, 5, 15, 0)
                },
                //expired flights for testing
                new Flight
                {
                    flightId = "EVA218",
                    flightSource = "SEPANG, MALAYSIA",
                    flightDestination = "TAIPEI, TAIWAN",
                    flightDateTime = new System.DateTime(2022, 05, 17, 15, 5, 15, 0)
                }
           );
        }
    }


}
