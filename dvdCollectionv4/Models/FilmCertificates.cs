using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace dvdCollection.Models {

    public class FilmCertificates {
        [Key]
        [Display(Name="ID")]
        public int CertificateID { get; set;}
        [Display(Name="Description",Prompt="Descripcion del certificado")]
        [Required(ErrorMessage="La descripcion del certificado es obligatoria")]
        [StringLength(10)]
        public string FilmCertificate { get; set;}

        public ICollection<FilmTitles> FilmTitles { get; set;}

    }
}