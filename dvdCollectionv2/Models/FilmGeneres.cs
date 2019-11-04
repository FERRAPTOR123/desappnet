using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace dvdCollection.Models {

    public class FilmGeneres {
        [Key]
        [Display(Name="ID")]
        public int GenereID { get; set;}
        [Display(Name="Description",Prompt="Descripcion del genero")]
        [Required(ErrorMessage="La descripcion del genero es obligatoria")]
        [StringLength(60)]
        public string GenreDesc { get; set;}

        public ICollection<FilmTitles> FilmTitles { get; set;}

    }
}