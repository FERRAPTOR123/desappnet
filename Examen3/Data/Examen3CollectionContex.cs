
using Microsoft.EntityFrameworkCore;
using Examen3.Models;


namespace Examen3.Data 
{
    public class Examen3CollectionContext : DbContext
    {
        public Examen3CollectionContext(DbContextOptions<Examen3CollectionContext> options) : base(options) 
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
           modelBuilder.Entity<Customer>().HasKey(c => new {c.CustomerID});
            //modelBuilder.Entity<FilmsActorRoles>().HasKey(c => new {c.FilmTitleID, c.ActorID, c.RoleTypeID});
        }
       
    } 
}