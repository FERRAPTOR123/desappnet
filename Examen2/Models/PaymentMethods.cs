using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Examen2.Models {

    public class PaymentMethods {
        public int PaymentMethodsID {get; set;}

        [Display(Name="PaymentMethod",Prompt="PaymentMethod")]
        [StringLength(300)]
        public string PaymentMethod { get; set;}
        

        
    }
}