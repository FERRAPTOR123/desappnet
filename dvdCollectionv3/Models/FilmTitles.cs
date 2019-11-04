using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace dvdCollection.Models {

    public class FilmTitles {
        [Key]
        [Display(Name="ID")]
        public int FilmTitleID { get; set;}
        [Display(Name="Title",Prompt="Titulo de la pelicula")]
        [Required(ErrorMessage="El Titulo de la pelicula es obligatorio")]
        [StringLength(100)]
        public string FilmTitle { get; set;}
        [Display(Name="Story",Prompt="Historia de la pelicula")]
        [Required(ErrorMessage="La Historia de la pelicula es obligatoria")]
        [StringLength(300)]
        public string FilmStory { get; set;}
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString="{0:dd-MM-yyyy}",ApplyFormatInEditMode=true)]
        public DateTime FilmRelaseDate { get; set;}
        public int FilmDuration { get; set;}
        public int FilmGenereID { get; set;}
        public int FilmCertificateID { get; set;}
        public string FilmAdditionalInfo { get; set;}

        public FilmGeneres FilmGenere { get; set;}
        public FilmCertificates FilmCertificate { get; set;}

        public ICollection<FilmTitlesProducers> FilmTitlesProducers { get; set;}
        public ICollection<FilmsActorRoles> FilmActorRoles { get; set;}

         

    }
}