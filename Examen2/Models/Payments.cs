using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Examen2.Models {

    public class Payments {
        public int PaymentID {get; set;}

        public int CustomerID {get; set;}

        public int BookingID {get; set;}

        public string PaymentMethodID { get; set;}

        [Display(Name="PaymentAmount",Prompt="PaymentAmount")]
        [StringLength(300)]
        public string PaymentAmount { get; set;}

        [Display(Name="PaymentComments",Prompt="PaymentComments")]
        [StringLength(300)]
        public string PaymentComments { get; set;}

        public Customer Customer {get; set;}
        public Bookings Bookings {get; set;}
        public Bookings PaymentMethods {get; set;}

        public ICollection<PaymentMethods> PaymentMethod { get; set;}  
        
    }
}