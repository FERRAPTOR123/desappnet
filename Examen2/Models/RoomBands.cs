using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Examen2.Models {

    public class RoomBands {
        public int RoomBandsID {get; set;}

        [Display(Name="RoomBandsDesc",Prompt="RoomBandsDesc")]
        [StringLength(300)]
        public string RoomBandsDesc { get; set;}

        public ICollection<Rooms> Rooms { get; set;}   
    }
}