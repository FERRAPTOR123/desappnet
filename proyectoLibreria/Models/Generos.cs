using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace proyecto.Models {

    public class Generos {
        [Key]
        [Display(Name="ID")]
        public int GeneroID { get; set;}
        [Display(Name="Description",Prompt="Descripcion del genero")]
        [Required(ErrorMessage="La descripcion del genero es obligatoria")]
        [StringLength(60)]
        public string GeneroDesc { get; set;}

        public ICollection<Titulos> Titulo { get; set;}

    }
}