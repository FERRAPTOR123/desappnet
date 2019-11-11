using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Examen3.Models {

    public class FacilitiesList {
        public int FacilityID {get; set;}

        [Display(Name="FacilitiesDesc",Prompt="FacilitiesDesc")]
        [StringLength(300)]
        public string FacilitiesDesc { get; set;}
        

        public ICollection<RoomsFacilities> RoomsFacilities { get; set;}  
    }
}