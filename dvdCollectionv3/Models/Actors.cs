using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace dvdCollection.Models {

    public class Actors {
        [Key]
        [Display(Name="ID")]
        public int ActorID { get; set;}
        [Display(Name="Name",Prompt="Nombre completo del actor")]
        [Required(ErrorMessage="El nombre del actor es obligatorio")]
        [StringLength(80)]
        public string ActorFullName { get; set;}
        [Display(Name="Notes",Prompt="Notas adicionales del actor")]
        [StringLength(300)]
        public string ActorNotes { get; set;}

        public ICollection<FilmsActorRoles> FilmActorRoles { get; set;}

    }
}