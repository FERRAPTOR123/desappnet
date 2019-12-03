using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace proyecto.Models {

    public class Imprenta {
        [Key]
        [Display(Name="ID")]
        public int ImprentaID {get; set;}
        [Display(Name="Name",Prompt="Nombre completo de la inprenta")]
        [Required(ErrorMessage="El nombre de la imprenta es obligatorio")]
        [StringLength(80)]
        public string ImprentaName {get; set;}
        [Display(Name="Email",Prompt="Correo Electronico de la imprenta")]
        [DataType(DataType.EmailAddress)]
        public string ContactEmailAddress {get; set;}
        [DataType(DataType.Url)]
        public string WebSite {get; set;}

        public ICollection<Editorial> Editorial {get; set;}
    }
}