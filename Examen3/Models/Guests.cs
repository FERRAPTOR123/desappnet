using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Examen3.Models {

    public class Guests {
        [Key]
        [Display(Name="ID")]
        public int GuestID { get; set;}

        [Display(Name="GuestTitle",Prompt="GuestTitle")]
        [Required(ErrorMessage="El nombre del GuestTitle es obligatorio")]
        [StringLength(80)]
        public string GuestTitle { get; set;}
        
        [Display(Name="GuestForenames",Prompt="GuestForenames")]
        [StringLength(300)]
        public string GuestForenames { get; set;}

        [Display(Name="GuestSurnames",Prompt="GuestSurnames")]
        [StringLength(300)]
        public string GuestSurnames { get; set;}

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString="{0:dd-MM-yyyy}",ApplyFormatInEditMode=false)]
        public DateTime GuestDOB { get; set;}

        [Display(Name="GuestAddressStreet",Prompt="GuestAddressStreet")]
        [StringLength(300)]
        public string GuestAddressStreet { get; set;}

        [Display(Name="GuestAddressTown",Prompt="GuestAddressTown")]
        [StringLength(300)]
        public string GuestAddressTown { get; set;}

        [Display(Name="GuestAddressPostalCode",Prompt="GuestAddressPostalCode")]
        [StringLength(300)]
        public string GuestAddressPostalCode { get; set;}

        [Display(Name="GuestContactePhone",Prompt="GuestContactePhone")]
        [StringLength(300)]
        public string GuestContactePhone { get; set;}


        public ICollection<BookingsRooms> BookingsRooms { get; set;}  
    }
}