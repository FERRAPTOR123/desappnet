using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Examen3.Models {

    public class RoomTypes {
        public int RoomTypesID {get; set;}

        [Display(Name="RoomType",Prompt="RoomType")]
        [StringLength(300)]
        public string RoomType { get; set;}

        public ICollection<Rooms> Rooms { get; set;}  
        
    }
}