using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Examen2.Models {

    public class Rooms {
        public int RoomID {get; set;}

        public int RoomTypeID {get; set;}

        public int RoomBandID {get; set;}

        public int RoomPriceID {get; set;}

        public string PaymentMethodID { get; set;}

        [Display(Name="Floor",Prompt="Floor")]
        [StringLength(300)]
        public string Floor { get; set;}

        [Display(Name="AdditionalNotes",Prompt="AdditionalNotes")]
        [StringLength(300)]
        public string AdditionalNotes { get; set;}


        public RoomTypes RoomTypes {get; set;}
        public RoomBands RoomBands {get; set;}
        public RoomPrices RoomPrices {get; set;}
        
        public ICollection<RoomsFacilities> RoomsFacilities { get; set;}
    }
}