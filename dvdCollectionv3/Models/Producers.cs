using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace dvdCollection.Models {

    public class Producers {
        [Key]
        [Display(Name="ID")]
        public int ProducerID {get; set;}
        [Display(Name="Name",Prompt="Nombre completo del Productor")]
        [Required(ErrorMessage="El nombre del Productor es obligatorio")]
        [StringLength(80)]
        public string ProducerName {get; set;}
        [Display(Name="Email",Prompt="Correo Electronico del Productor")]
        [DataType(DataType.EmailAddress)]
        public string ContactEmailAddress {get; set;}
        [DataType(DataType.Url)]
        public string WebSite {get; set;}

        public ICollection<FilmTitlesProducers> FilmTitlesProducers {get; set;}
    }
}