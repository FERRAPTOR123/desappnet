using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Examen2.Models {

    public class RoomsFacilities {
        public int RoomID {get; set;}
        public int Facility {get; set;}

        [Display(Name="FacilityDetails",Prompt="FacilityDetails")]
        [StringLength(300)]
        public string FacilityDetails { get; set;}
         

        public FacilitiesList FacilitiesList {get; set;}
        public Rooms Rooms {get; set;}
    }
}