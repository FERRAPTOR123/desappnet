using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace proyecto.Models {

    public class Titulos {
        [Key]
        [Display(Name="ID")]
        public int TituloID { get; set;}
        [Display(Name="Title",Prompt="Titulo de la Libro")]
        [Required(ErrorMessage="El Titulo de la Libro es obligatorio")]
        [StringLength(100)]
        public string Titulo { get; set;}
        [Display(Name="Story",Prompt="Historia de la Libro")]
        [Required(ErrorMessage="La Historia de la Libro es obligatoria")]
        [StringLength(300)]
        public string Prologo { get; set;}
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString="{0:dd-MM-yyyy}",ApplyFormatInEditMode=false)]
        public DateTime LibroRelaseDate { get; set;}
        public int NumeroDePaginas { get; set;}
        public int GeneroID { get; set;}
        public Generos Generos { get; set;}
        

        public ICollection<Editorial> Editorial { get; set;}
       
         

    }
}