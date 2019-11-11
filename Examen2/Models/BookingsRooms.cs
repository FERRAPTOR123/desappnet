using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Examen2.Models {

    public class BookingsRooms {
        public int BookingID {get; set;}
        public int RoomID {get; set;}
        public int GuestID {get; set;}

         

        public Bookings Bookings {get; set;}
        public Payments Payments {get; set;}
        public Guests Guests {get; set;}
        public Rooms Rooms {get; set;}

        public ICollection<Bookings> Booking { get; set;} 
        public ICollection<Payments> Payment { get; set;} 
        public ICollection<Guests> Guest { get; set;} 
        public ICollection<Rooms> Room { get; set;} 
    }
}