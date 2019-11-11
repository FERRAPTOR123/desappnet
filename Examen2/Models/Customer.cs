using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Examen2.Models {

    public class Customer {
        [Key]
        [Display(Name="ID")]
        public int CustomerID { get; set;}

        [Display(Name="CustomerTitle",Prompt="Nombre completo del cliente")]
        [Required(ErrorMessage="El nombre del cliente es obligatorio")]
        [StringLength(80)]
        public string CustomerTitle { get; set;}
        
        [Display(Name="CustomerForenames",Prompt="CustomerForenames")]
        [StringLength(300)]
        public string CustomerForenames { get; set;}

        [Display(Name="CustomerSurnames",Prompt="CustomerSurnames")]
        [StringLength(300)]
        public string CustomerSurnames { get; set;}

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString="{0:dd-MM-yyyy}",ApplyFormatInEditMode=false)]
        public DateTime CustomerDOB { get; set;}

        [Display(Name="CustomerAddressStreet",Prompt="CustomerAddressStreet")]
        [StringLength(300)]
        public string CustomerAddressStreet { get; set;}

        [Display(Name="CustomerAddressTown",Prompt="CustomerAddressTown")]
        [StringLength(300)]
        public string CustomerAddressTown { get; set;}

        [Display(Name="CustomerAddressPostalCode",Prompt="CustomerAddressPostalCode")]
        [StringLength(300)]
        public string CustomerAddressPostalCode { get; set;}

        [Display(Name="CustomerHomePhone",Prompt="CustomerHomePhone")]
        [StringLength(300)]
        public string CustomerHomePhone { get; set;}

        [Display(Name="CustomerWorkPhone",Prompt="CustomerWorkPhone")]
        [StringLength(300)]
        public string CustomerWorkPhone { get; set;}

        [Display(Name="CustomerMobilePhone",Prompt="CustomerMobilePhone")]
        [StringLength(300)]
        public string CustomerMobilePhone { get; set;}

        [Display(Name="CustomerEmail",Prompt="CustomerEmail")]
        [StringLength(300)]
        public string CustomerEmail { get; set;}

        public ICollection<Bookings> Bookings { get; set;}  
    }
}