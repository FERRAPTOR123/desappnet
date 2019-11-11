
using Microsoft.EntityFrameworkCore;
using Examen2.Models;


namespace Examen2.Data 
{
    public class Examen2CollectionContext : DbContext
    {
        public Examen2CollectionContext(DbContextOptions<Examen2CollectionContext> options) : base(options) 
        {
        }

        public DbSet<Bookings> Bookings {get; set;}
        public DbSet<BookingsRooms> BookingsRooms {get; set;}
        public DbSet<Customer> Customer {get; set;}
        public DbSet<FacilitiesList> FacilitiesList {get; set;}
        public DbSet<Guests> Guests {get; set;}
        public DbSet<PaymentMethods> PaymentMethods {get; set;}
        public DbSet<Payments> Payments {get; set;}
        public DbSet<RoomBands> RoomBands {get; set;}
        public DbSet<RoomPrices> RoomPrices {get; set;}
        public DbSet<Rooms> Rooms {get; set;}
        public DbSet<RoomsFacilities> RoomsFacilities {get; set;}
        public DbSet<RoomTypes> RoomTypes {get; set;}


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           // modelBuilder.Entity<FilmTitlesProducers>().HasKey(c => new {c.ProducerID, c.FilmTitleID});
            //modelBuilder.Entity<FilmsActorRoles>().HasKey(c => new {c.FilmTitleID, c.ActorID, c.RoleTypeID});
        }
       
    } 
}