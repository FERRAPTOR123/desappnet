using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Examen2.Models {

    public class RoomPrices {
        public int RoomPricesID {get; set;}

        [Display(Name="RoomPrice",Prompt="RoomPrice")]
        [StringLength(300)]
        public string RoomPrice { get; set;}
        

        public ICollection<Rooms> Rooms { get; set;}  
    }
}