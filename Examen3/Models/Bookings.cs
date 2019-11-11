using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Examen3.Models {

    public class Bookings {
        public int BookingsID {get; set;}
        public int CustomerID {get; set;}

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString="{0:dd-MM-yyyy}",ApplyFormatInEditMode=false)]
        public DateTime DateBookingMade { get; set;}

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString="{0:dd-MM-yyyy}",ApplyFormatInEditMode=false)]
        public DateTime TimeBookingMade { get; set;}

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString="{0:dd-MM-yyyy}",ApplyFormatInEditMode=false)]
        public DateTime BookedStartDate { get; set;}
        
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString="{0:dd-MM-yyyy}",ApplyFormatInEditMode=false)]
        public DateTime BookedEndDate { get; set;}

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString="{0:dd-MM-yyyy}",ApplyFormatInEditMode=false)]
        public DateTime TotalPaymentDueDate { get; set;}

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString="{0:dd-MM-yyyy}",ApplyFormatInEditMode=false)]
        public DateTime TotalPaymentMadeOn { get; set;}

        [Display(Name="BookingComments",Prompt="BookingComments")]
        [StringLength(300)]
        public string BookingComments { get; set;}
        public Customer Customer {get; set;}

        public ICollection<Payments> Payments { get; set;}  
        
    }
}